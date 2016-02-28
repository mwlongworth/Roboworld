// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LuaPackage.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Gateway.WebApi.Ioc
{
    using Roboworld.Lua;

    using SimpleInjector;
    using SimpleInjector.Packaging;

    public class LuaPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterSingleton<ILuaRepository, LuaRepository>();
        }
    }
}