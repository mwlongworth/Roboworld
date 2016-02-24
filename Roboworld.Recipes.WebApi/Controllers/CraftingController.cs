// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingController.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Controllers
{
    using System.Web.Http;

    using NHibernate;

    using Roboworld.Recipes.WebApi.Orm;

    [RoutePrefix("crafting")]
    public class CraftingController : ApiController
    {
        private readonly ISession session;

        public CraftingController(ISession session)
        {
            this.session = session;
        }

        [HttpGet]
        [Route("recipes")]
        public IHttpActionResult GetAll()
        {
            return this.Ok(session.QueryOver<CraftingRecipe>().List());
        }

        [HttpGet]
        [Route("recipes/{id}")]
        public IHttpActionResult GetById(int id)
        {
            return this.Ok();
        }
    }
}