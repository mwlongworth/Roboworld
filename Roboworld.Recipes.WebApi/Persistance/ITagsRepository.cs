// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITagsRepository.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Persistance
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Roboworld.Recipes.WebApi.Orm;

    public interface ITagsRepository
    {
        Task<IReadOnlyList<Tag>> GetAllTagsAsync();

        Task<Tag> GetByTextAsync(string tagText);

        Task<Tag> GetOrCreateTagAsync(string tagText);

        Task SaveAsync(Tag tag);
    }
}