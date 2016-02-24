// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessingController.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Controllers
{
    using System;
    using System.Web.Http;

    using Roboworld.Recipes.WebApi.Processing;

    [RoutePrefix("processing")]
    public class ProcessingController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAll()
        {
            return this.Ok(new[] { Enum.GetNames(typeof(RecipeType)) });
        }
    }
}