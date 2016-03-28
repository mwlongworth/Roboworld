// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsRepository.cs" company="Matthew Longworth">
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

    public class ItemsRepository : IItemsRepository
    {
        private readonly ISession session;

        public ItemsRepository(ISession session)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            this.session = session;
        }

        public Task<IReadOnlyList<Item>> GetAllItemsAsync()
        {
            var items = (IReadOnlyList<Item>)this.session.QueryOver<Item>().List();

            return Task.FromResult(items);
        }

        public Task SaveAsync(Item item)
        {
            this.session.SaveOrUpdate(item);
            return Task.FromResult(0);
        }

        public Task SaveAsync(ItemVariant variant)
        {
            this.session.SaveOrUpdate(variant);
            return Task.FromResult(0);
        }

        public Task SaveAsync(Mod mod)
        {
            this.session.SaveOrUpdate(mod);
            return Task.FromResult(0);
        }

        public Task<Item> GetByModAndNameAsync(string mod, string name)
        {
            var item = this.session.Query<Item>().SingleOrDefault(o => o.Mod.Name == mod && o.Slug == name);
            return Task.FromResult(item);
        }

        public Task<ItemVariant> GetVariant(string mod, string name, int meta)
        {
            var item =
                this.session.Query<ItemVariant>()
                    .SingleOrDefault(o => o.Item.Mod.Name == mod && o.Item.Slug == name && o.Metadata == meta);
            return Task.FromResult(item);
        }

        public Task<Mod> GetModAsync(string mod)
        {
            var item = this.session.QueryOver<Mod>().Where(o => o.Slug == mod).SingleOrDefault();
            return Task.FromResult(item);
        }
    }
}