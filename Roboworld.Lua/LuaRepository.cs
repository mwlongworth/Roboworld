// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LuaRepository.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Lua
{
    using System.Globalization;
    using System.Threading.Tasks;

    public class LuaRepository : ILuaRepository
    {
        public Task<string> LuaScriptAsync(string name)
        {
            var fullName = string.Format(CultureInfo.InvariantCulture, "{0}.lua", name);
            var loader = new EmbeddedResourceLoader();
            return loader.LoadResourceAsync(fullName);
        }
    }
}