﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SoftwareController.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Gateway.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Roboworld.Lua;

    /// <summary>
    /// Allows robots and computers in-game to download software
    /// </summary>
    [RoutePrefix("software")]
    public class SoftwareController : ApiController
    {
        private readonly ILuaRepository luaRepository;

        public SoftwareController(ILuaRepository luaRepository)
        {
            this.luaRepository = luaRepository;
        }

        [HttpGet]
        [Route("bootstrap")]
        public async Task<IHttpActionResult> GetBootstrapper()
        {
            // Get the bootstrapper - a single program that allows the rest of the software to be downloaded
            // This is done by gluing various files together
            var allTasks = this.GetAllFilesForBootstrap().ToList();

            await Task.WhenAll(allTasks);
            var completeFile = new StringBuilder();
            var addNewline = false;
            foreach (var script in allTasks)
            {
                if (addNewline)
                {
                    completeFile.AppendLine();
                }

                completeFile.Append(script.Result);

                addNewline = true;
            }

            return this.Ok(completeFile.ToString());
        }

        private IEnumerable<Task<string>> GetAllFilesForBootstrap()
        {
            yield return this.luaRepository.LuaLibraryAsync("webApiClient");
            yield return this.luaRepository.LuaLibraryAsync("softwareClient");
            yield return this.luaRepository.LuaLibraryAsync("serialization");
            yield return this.luaRepository.LuaLibraryAsync("files");
            yield return this.luaRepository.LuaScriptAsync("bootstrap");
        }

        [HttpGet]
        [Route("update")]
        public IHttpActionResult GetAllUpdates()
        {
            var libraries = new[] { "webApiClient", "softwareClient", "serialization", "files", };
            var table = GetValue(libraries);

            return this.Ok(table);
        }

        private static string GetValue(IEnumerable<string> values)
        {
            var sb = new StringBuilder("{");
            var addComma = false;
            foreach (var value in values)
            {
                if (addComma)
                {
                    sb.Append(",");
                }

                sb.Append("\"");
                sb.Append(value);
                sb.Append("\"");
                addComma = true;
            }

            sb.Append("}");
            return sb.ToString();
        }

        [HttpGet]
        [Route("script/{name}")]
        public Task<IHttpActionResult> GetScript(string name)
        {
            return this.LuaLibrary(name);
        }

        [HttpGet]
        [Route("library/{name}")]
        public Task<IHttpActionResult> GetLibrary(string name)
        {
            return this.LuaLibrary(name);
        }

        private async Task<IHttpActionResult> LuaScript(string name)
        {
            var content = await this.luaRepository.LuaScriptAsync(name);

            return this.Ok(content);
        }

        private async Task<IHttpActionResult> LuaLibrary(string name)
        {
            var content = await this.luaRepository.LuaLibraryAsync(name);

            return this.Ok(content);
        }
    }
}