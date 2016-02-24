// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryPackage.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Ioc
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.IO;

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using FluentNHibernate.Conventions.Helpers;

    using NHibernate;

    using Orm;

    using Roboworld.Recipes.WebApi.Conventions;

    using SimpleInjector;
    using SimpleInjector.Packaging;

    public class RepositoryPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            var factory = Factory();
            container.Register<ISession>(() => factory.OpenSession(), Lifestyle.Scoped);
        }

        private static ISessionFactory Factory()
        {
            var baseType = typeof(CraftingRecipe);
            var ormNamespace = baseType.Namespace ?? string.Empty;

            var writer = new StringWriter();

            //AutoMap.AssemblyOf<CraftingRecipe>()
            //    //.OverrideAll(
            //    //    p =>
            //    //    p.IgnoreProperties(
            //    //        x => x.MemberInfo.GetCustomAttributes(typeof(NotMappedAttribute), false).Length > 0))
            //    .Conventions.AddFromAssemblyOf<EnumConvention>()
            //    .Conventions.Add(ForeignKey.EndsWith("Id"))
            //    .WriteMappingsTo(writer);


            return
                Fluently.Configure()
                    .Database(
                        MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("dev-db")))
                    .Mappings(
                        m =>
                        m.AutoMappings.Add(
                            AutoMap.AssemblyOf<CraftingRecipe>()
                            .Where(type => type.Namespace != null && type.Namespace.StartsWith(ormNamespace))
                            .Conventions.AddFromAssemblyOf<EnumConvention>()
                            .Conventions.Add(ForeignKey.EndsWith("Id"))
                            .Conventions.Add(DefaultCascade.All(), DefaultLazy.Always())))
                    .BuildSessionFactory();
        }
    }
}