// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.WebApp.Controllers
{
    using System.IO;
    using System.Web.Mvc;

    using Roboworld.WebApp.Models;

    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Index(SimpleUploadViewModel model)
        {
            var file = model.File;
            string txt = null;
            using (var reader = new StreamReader(file.InputStream))
            {
                txt = reader.ReadToEndAsync().Result;
            }

            return this.Content(txt);
        }
    }
}