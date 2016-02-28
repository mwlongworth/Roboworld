// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILuaRepository.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Lua
{
    using System.Threading.Tasks;

    public interface ILuaRepository
    {
        Task<string> LuaScriptAsync(string scriptName);

        Task<string> LuaLibraryAsync(string libraryName);
    }
}