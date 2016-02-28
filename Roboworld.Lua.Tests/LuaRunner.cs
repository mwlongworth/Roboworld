// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LuaRunner.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Lua.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Neo.IronLua;

    public class LuaRunner
    {
        private readonly ILuaRepository repository;

        private readonly IList<string> content;

        public LuaRunner(ILuaRepository repository)
        {
            this.repository = repository;
            this.content = new List<string>();
        }

        public LuaRunner AddLibraries(params string[] filenames)
        {
            foreach (var filename in filenames)
            {
                this.content.Add(this.repository.LuaLibraryAsync(filename).Result);
            }

            return this;
        }


        public object ExecuteString(string command)
        {
            object returnValue = null;

            using (var lua = new Lua())
            {
                dynamic environment = lua.CreateEnvironment();
                environment.output = new Action<object>(o => returnValue = o);
                environment.print = new Action<string>(Console.WriteLine);
                
                var ctr = 0;
                var chunks =
                    this.content.Select(o => lua.CompileChunk(o, "myfile" + (ctr++), new LuaCompileOptions())).ToList();

                foreach (var chunk in chunks)
                {
                    chunk.Run(environment);
                }

                var exec = lua.CompileChunk(command, "mycode", new LuaCompileOptions());
                exec.Run(environment);

                return returnValue;
            }
        }

        public interface IApi
        {
            IHttp http { get; }
        }

        public interface IHttpHandle
        {
            string readAll();
        }

        public interface IHttp
        {
            IHttpHandle get(string url);
        }

        
    }
}