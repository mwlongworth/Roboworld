// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UploadController.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.WebApp.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Newtonsoft.Json;

    using Roboworld.RecipeImporter;
    using Roboworld.WebApp.Crafting;
    using Roboworld.WebApp.Models;

    public class UploadController : Controller
    {
        private readonly INeiUploader neiUploader;

        public UploadController(INeiUploader neiUploader)
        {
            if (neiUploader == null) throw new ArgumentNullException(nameof(neiUploader));

            this.neiUploader = neiUploader;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(SimpleUploadViewModel model)
        {
            if (model.File == null)
            {
                this.TempData.Add("flash-danger", "No file was uploaded!");
                return this.View();
            }

            var file = model.File;

            using (var archive = new ArchiveReader(file.InputStream))
            using (var provider = new NeiDataProvider(archive))
            {
                var neiImporter = new NeiImporter(provider);
                var items = neiImporter.GetAllItems();
                var variants = neiImporter.GetAllItemVariants();

              //  await this.neiUploader.UploadItemsAsync(items);
                //await this.neiUploader.UploadVariantsAsync(variants);

                return this.Content(JsonConvert.SerializeObject(variants));
            }
        }
    }
}