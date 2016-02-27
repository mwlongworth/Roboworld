// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RobotController.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Communication.WebApi.Controllers
{
    using System;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
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
            return this.Content(HttpStatusCode.OK, "p");
        }

        [HttpPost]
        [Route("peripheral")]
        public IHttpActionResult PostPeripheral()
        {
            return this.Content(HttpStatusCode.OK, "Ok, got it!");
        }
    }
}