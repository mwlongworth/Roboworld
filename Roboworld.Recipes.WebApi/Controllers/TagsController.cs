// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagsController.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    using AutoMapper;

    using Newtonsoft.Json;

    using Roboworld.Recipes.WebApi.Persistance;

    [RoutePrefix("tags")]
    public class TagsController : ApiController
    {
        private readonly ITagsRepository repository;
        private readonly IMapper mapper;

        public TagsController(ITagsRepository repository, IMapper mapper)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAllTags()
        {
            var items = await this.repository.GetAllTagsAsync();
            return this.Ok(items);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> PutTag(object tag)
        {
            var tagText = JsonConvert.SerializeObject(tag, Formatting.None);
            var existing = await this.repository.GetOrCreateTagAsync(tagText);

            return this.Ok(existing.Id);
        }
    }
}