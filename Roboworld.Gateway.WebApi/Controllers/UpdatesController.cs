namespace Roboworld.Gateway.WebApi.Controllers
{
    using System.Net;
    using System.Web.Http;

    /// <summary>
    /// Allows robots and computers in-game to perform software updates
    /// </summary>
    [RoutePrefix("updates")]
    public class UpdatesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllUpdates()
        {
            return this.Content(HttpStatusCode.OK, "{\"alpha\",\"beta\",\"gamma\"}");
        }
    }
}