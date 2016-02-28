// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SoftwareController.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Gateway.WebApi.Controllers
{
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
            var files = new[] { "webApiClient", "softwareClient", "bootstrap" };

            var allTasks = files.Select(o => this.luaRepository.LuaScriptAsync(o)).ToList();

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

        [HttpGet]
        [Route("update")]
        public IHttpActionResult GetAllUpdates()
        {
            return this.Content(HttpStatusCode.OK, "{\"alpha\",\"beta\",\"gamma\"}");
        }

        [HttpGet]
        [Route("library/{name}")]
        public Task<IHttpActionResult> GetLibrary(string name)
        {
            return this.Lua(name);
        }

        private async Task<IHttpActionResult> Lua(string name)
        {
            var content = await this.luaRepository.LuaScriptAsync(name);

            return this.Ok(content);
        }
    }
}