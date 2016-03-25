// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.WebApp.Controllers
{
    using System.IO;
    using System.Web.Mvc;

    using Newtonsoft.Json;

    using Roboworld.RecipeImporter;
    using Roboworld.WebApp.Models;

    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }
    }
}