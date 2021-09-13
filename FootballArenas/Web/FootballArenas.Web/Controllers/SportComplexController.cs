using System;
using System.Collections.Generic;
using Castle.Core.Internal;
using FootballArenas.Data.Models.CustomModels;
using FootballArenas.Services.Data.Properties.Image;
using Microsoft.AspNetCore.Hosting;

namespace FootballArenas.Web.Controllers
{
    using System.Threading.Tasks;

    using FootballArenas.Services.Data;
    using FootballArenas.Services.Data.User;
    using FootballArenas.Web.ViewModels.SportComplexViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class SportComplexController : BaseController
    {
        private readonly ISportComplexService sportComplexService;
        private readonly IFootballArenaUserService footballArenaUserService;
        private readonly IWebHostEnvironment environment;
        private readonly IImageService imageService;

        public SportComplexController(
            ISportComplexService sportComplexService,
            IFootballArenaUserService footballArenaUserService,
            IWebHostEnvironment environment,
            IImageService imageService)
        {
            this.sportComplexService = sportComplexService;
            this.footballArenaUserService = footballArenaUserService;
            this.environment = environment;
            this.imageService = imageService;
        }

        public IActionResult Add()
        {
            var viewModel = new SportComplexInputViewModel();

            if (this.footballArenaUserService.GetUsersWithoutSportComplex().Count < 1)
            {
                return this.Redirect("/Identity/Account/Register");
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SportComplexInputViewModel viewModel)
        {
            try
            {
                await this.sportComplexService.AddSportComplex(viewModel, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, e.Message);
                return this.View(viewModel);
            }

            return this.Redirect("/");
        }

        public IActionResult SetMainImage(int id)
        {
            var model = this.sportComplexService.GetById(id);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SetMainImage(HomePageSportComplexViewModel model)
        {
            int counter = 0;
            if (model.ImageList.IsNullOrEmpty())
            {
                this.ModelState.AddModelError(string.Empty, "There are no images for this complex.");
                return this.Redirect("/" );
            }

            foreach (var image in model.ImageList)
            {
                if (image.IsMainImage == true)
                {
                    counter++;
                }
            }

            if (counter > 1)
            {
                this.ModelState.AddModelError(string.Empty, "Select only one picture.");
                return this.View(model);
            }

            await this.imageService.SetMainImage(model.Id, model.ImageList);
            return this.Redirect("/");
        }

        public IActionResult UploadNewImages(int id)
        {
            var sportComplex = this.sportComplexService.GetOriginalSportComplexById(id);
            var viewModel = new SportComplexInputViewModel
            {
                Id = sportComplex.Id,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UploadNewImages(SportComplexInputViewModel input)
        {
            await this.sportComplexService.UploadNewImages(input, $"{this.environment.WebRootPath}/images");
            return this.Redirect("/");
        }

        public IActionResult EditSportComplex(int id)
        {
            var model = this.sportComplexService.GetInputModelById(id);
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditSportComplex(SportComplexInputViewModel input)
        {
            await this.sportComplexService.EditSportComplex(input);
            return this.RedirectToAction("EditSportComplex", new { id = input.Id });
        }

        public IActionResult DeleteImages(int id)
        {
            var model = this.sportComplexService.GetById(id);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImages(HomePageSportComplexViewModel input)
        {
            await this.imageService.DeleteImages(input.Id, input.ImageList);
            return this.RedirectToAction("SetMainImage", new { id = input.Id });
        }

        public async Task<IActionResult> DeleteSportComplex(int id)
        {
            await this.sportComplexService.DeleteSportComplexById(id);
            return this.Redirect("/");
        }

        public IActionResult AddFootballFields(int id)
        {
            var sportComplex = this.sportComplexService.GetOriginalSportComplexById(id);
            var viewModel = new SportComplexInputViewModel
            {
                Id = sportComplex.Id,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddFootballFields(SportComplexInputViewModel input)
        {
            try
            {
                await this.sportComplexService.AddFootballFields(input);
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, e.Message);
                return this.View(input);
            }
            return this.Redirect("/");
        }

        public IActionResult EditFootballField(int id)
        {
            var sportComplex = this.sportComplexService.GetInputModelById(id);
            return this.View(sportComplex);
        }

        [HttpPost]
        public async Task<IActionResult> EditFootballField(SportComplexInputViewModel input)
        {
            await this.sportComplexService.EditFootballFields(input);
            return this.RedirectToAction("EditFootballField", new {id = input.Id});
        }

        public IActionResult DeleteFootballFields(int id)
        {
            var sportComplex = this.sportComplexService.GetInputModelById(id);
            return this.View(sportComplex);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFootballFieldsById(SportComplexInputViewModel field)
        {
             await this.sportComplexService.DeleteFootballFields(field.Id);
             return this.Redirect("/");
        }
    }
}
