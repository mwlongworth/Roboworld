﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IItemsRepository.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Persistance
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Roboworld.Recipes.WebApi.Orm;

    public interface IItemsRepository
    {
        Task<IReadOnlyList<Item>> GetAllItemsAsync();

        Task SaveAsync(Item item);

        Task SaveAsync(ItemVariant variant);

        Task SaveAsync(Mod mod);

        Task<Item> GetByModAndNameAsync(string mod, string name);

        Task<ItemVariant> GetVariant(string mod, string name, int meta);

        Task<Mod> GetModAsync(string mod);
    }
}