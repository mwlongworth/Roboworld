// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsController.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Controllers
{
    using System;
    using System.Web.Http;

    using AutoMapper;

    using NHibernate;

    using Roboworld.Recipes.WebApi.Dto;
    using Roboworld.Recipes.WebApi.Orm;

    [RoutePrefix("items")]
    public class ItemsController : ApiController
    {
        private readonly ISession session;
        private readonly IMapper mapper;

        public ItemsController(ISession session, IMapper mapper)
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
            return this.Ok(this.session.QueryOver<Item>().List());
        }

        [HttpGet]
        [Route("test")]
        public IHttpActionResult JsonTest()
        {
            return this.Ok(new object[] { 1, "two", "3" });
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateItem(CreateItemDto item)
        {
            var entity = this.mapper.Map<Item>(item);
            this.session.Save(entity);

            return this.Ok(entity);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult EditItem(int id, CreateItemDto item)
        {
            var entity = this.session.QueryOver<Item>().Where(o => o.Id == id).SingleOrDefault();

            this.mapper.Map(item, entity);
            using (var transaction = this.session.BeginTransaction())
            {
                this.session.Update(entity);
                transaction.Commit();
            }

            return this.Ok(entity);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            return this.Ok(this.session.QueryOver<Item>().Where(o => o.Id == id).SingleOrDefault());
        }

        [HttpGet]
        [Route("{itemId}/recipes")]
        public IHttpActionResult GetAllRecipes(int itemId)
        {
            var craftingRecipes = this.session.QueryOver<CraftingRecipe>().Where(o => o.Output.Id == itemId).List();

            return this.Ok(craftingRecipes);
        }
    }
}