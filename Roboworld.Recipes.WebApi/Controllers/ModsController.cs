namespace Roboworld.Recipes.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using AutoMapper;

    using NHibernate;
    using NHibernate.Linq;

    using Roboworld.Recipes.WebApi.Dto;
    using Roboworld.Recipes.WebApi.Orm;

    [RoutePrefix("mods")]
    public class ModsController : ApiController
    {
        private readonly ISession session;

        private readonly IMapper mapper;

        public ModsController(ISession session, IMapper mapper)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            this.session = session;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return this.Ok(this.session.QueryOver<Mod>().List());
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult PostMod()
        {
            return this.Ok(this.session.QueryOver<Mod>().List());
        }

        [HttpGet]
        [Route("{modId}")]
        public IHttpActionResult GetSingle(int modId)
        {
            var mod = this.session.Query<Mod>().SingleOrDefault(o => o.Id == modId);

            return mod == null ? (IHttpActionResult)this.NotFound() : this.Ok(mod);
        }

        [HttpGet]
        [Route("{modId}/items")]
        public IHttpActionResult GetAllItems(int modId)
        {
            var craftingRecipes = this.session.QueryOver<Item>().Where(o => o.Mod.Id == modId).List();

            return this.Ok(craftingRecipes);
        }

        [HttpPost]
        [Route("{modId}/items/{itemName}/recipes")]
        public IHttpActionResult Set(string modId, string itemName, PostCraftingRecipeRequest request)
        {
            return this.Ok(this.session.QueryOver<CraftingRecipe>().List());
        }
    }
}