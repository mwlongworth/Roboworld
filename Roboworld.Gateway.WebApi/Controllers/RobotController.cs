// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RobotController.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Gateway.WebApi.Controllers
{
    using System.Net;
    using System.Web.Http;

    [RoutePrefix("robot")]
    public class RobotController : ApiController
    {
        [HttpGet]
        [Route("update")]
        public IHttpActionResult GetUpdates()
        {
            return this.Content(HttpStatusCode.OK, "Hello there robot");
        }

        [HttpGet]
        [Route("command")]
        public IHttpActionResult GetCommand()
        {
            return this.Content(HttpStatusCode.OK, "Yes, it is working");
        }

        [HttpPost]
        [Route("peripheral")]
        public IHttpActionResult PostPeripheral()
        {
            return this.Content(HttpStatusCode.OK, "Ok, got it!");
        }
    }
}