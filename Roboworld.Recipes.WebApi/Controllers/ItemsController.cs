// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsController.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    using AutoMapper;

    using Roboworld.Recipes.WebApi.Dto;
    using Roboworld.Recipes.WebApi.Orm;
    using Roboworld.Recipes.WebApi.Persistance;

    [RoutePrefix("items")]
    public class ItemsController : ApiController
    {
        private readonly IItemsRepository repository;
        private readonly IMapper mapper;

        public ItemsController(IItemsRepository repository, IMapper mapper)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            var items = await this.repository.GetAllItemsAsync();
            return this.Ok(items);
        }

        [HttpGet]
        [Route("test")]
        public async Task<IHttpActionResult> JsonTest()
        {
            return this.Ok(new object[] { 1, "two", "3" });
        }
        
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateItem(CreateItemDto item)
        {
            var entity = this.mapper.Map<Item>(item);
            await this.repository.SaveAsync(entity);

            return this.Ok(entity);
        }

        /*
        [HttpPut]
        [Route("{id}")]
        public Task<IHttpActionResult> EditItem(int id, CreateItemDto item)
        {
            var entity = this.repository.QueryOver<Item>().Where(o => o.Id == id).SingleOrDefault();

            this.mapper.Map(item, entity);
            using (var transaction = this.repository.BeginTransaction())
            {
                this.repository.Update(entity);
                transaction.Commit();
            }

            return this.Ok(entity);
        }*/

        [HttpPut]
        [Route("{mod}/{name}")]
        public async Task<IHttpActionResult> PutByModAndName(string mod, string name, PutItemRequest item)
        {
            var existing = await this.repository.GetByModAndNameAsync(mod, name);

            if (existing == null)
            {
                existing = this.mapper.Map<Item>(item);
                var modEntity = await this.GetNewOrExistingMod(mod);
                existing.Mod = modEntity;
                existing.Slug = name;
            }
            else
            {
                this.mapper.Map(item, existing);
            }

            await this.repository.SaveAsync(existing);

            var response = this.mapper.Map<ItemResponse>(existing);
            return this.Ok(response);
        }

        private async Task<Mod> GetNewOrExistingMod(string mod)
        {
            var existing = await this.repository.GetModAsync(mod);

            if(existing == null)
            {
                existing = new Mod
                               {
                                   Slug = mod,
                                   Name = mod,
                                   Version = "unknown"
                               };
                await this.repository.SaveAsync(existing);
            }

            return existing;
        }

        /*
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            return this.Ok(this.repository.QueryOver<Item>().Where(o => o.Id == id).SingleOrDefault());
        }

        [HttpGet]
        [Route("{itemId}/recipes")]
        public IHttpActionResult GetAllRecipes(int itemId)
        {
            var craftingRecipes = this.repository.QueryOver<CraftingRecipe>().Where(o => o.Output.Id == itemId).List();

            return this.Ok(craftingRecipes);
        }*/
    }
}