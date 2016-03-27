// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagsRepository.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Persistance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using NHibernate;
    using NHibernate.Linq;

    using Roboworld.Recipes.WebApi.Orm;

    public class TagsRepository : ITagsRepository
    {
        private readonly ISession session;

        public TagsRepository(ISession session)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            this.session = session;
        }

        public Task<IReadOnlyList<Tag>> GetAllTagsAsync()
        {
            var tags = (IReadOnlyList<Tag>)this.session.Query<Tag>().ToList();

            return Task.FromResult(tags);
        }

        public Task<Tag> GetByTextAsync(string tagText)
        {
            var tag = this.session.Query<Tag>().SingleOrDefault(o => o.TagText == tagText);

            return Task.FromResult(tag);
        }

        public Task<Tag> GetOrCreateTagAsync(string tagText)
        {
            var tag = this.session.Query<Tag>().SingleOrDefault(o => o.TagText == tagText);

            if (tag != null)
            {
                return Task.FromResult(tag);
            }

            var newTag = new Tag { TagText = tagText };
            this.session.SaveOrUpdate(newTag);
            return Task.FromResult(newTag);
        }

        public Task SaveAsync(Tag tag)
        {
            this.session.SaveOrUpdate(tag);
            return Task.FromResult(0);
        }
    }
}