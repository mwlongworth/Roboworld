// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LuaRunner.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Lua.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Moq;

    using Neo.IronLua;

    public class LuaRunner
    {
        private readonly IResourceLoader resourceLoader;

        private readonly IList<string> content;

        public LuaRunner(IResourceLoader resourceLoader)
        {
            this.resourceLoader = resourceLoader;
            this.content = new List<string>();
        }

        public LuaRunner AddLibraries(params string[] filenames)
        {
            foreach (var filename in filenames)
            {
                var fullName = string.Format(CultureInfo.InvariantCulture, "{0}.lua", filename);
                this.content.Add(this.resourceLoader.LoadResource(fullName));
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