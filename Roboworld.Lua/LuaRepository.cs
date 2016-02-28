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
        public Task<string> LuaScriptAsync(string scriptName)
        {
            var fullName = string.Format(CultureInfo.InvariantCulture, "Scripts.{0}.lua", scriptName);
            var loader = new EmbeddedResourceLoader();
            return loader.LoadResourceAsync(fullName);
        }

        public Task<string> LuaLibraryAsync(string libraryName)
        {
            var fullName = string.Format(CultureInfo.InvariantCulture, "Library.{0}.lua", libraryName);
            var loader = new EmbeddedResourceLoader();
            return loader.LoadResourceAsync(fullName);
        }
    }
}