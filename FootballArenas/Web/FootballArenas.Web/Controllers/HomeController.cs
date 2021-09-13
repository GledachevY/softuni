using Microsoft.AspNetCore.Hosting;

namespace FootballArenas.Web.Controllers
{
    using System.Diagnostics;
    using FootballArenas.Services.Data;
    using FootballArenas.Web.ViewModels.SportComplexViewModels;

    using FootballArenas.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ISportComplexService sportComplexService;
        private readonly IWebHostEnvironment environment;

        public HomeController(ISportComplexService sportComplexService, IWebHostEnvironment environment)
        {
            this.sportComplexService = sportComplexService;
            this.environment = environment;
        }

        public IActionResult Index()
        {

            var model = new CollectionWithSportComplexesViewModel
            {
                HomePageSportComplexViewModels = this.sportComplexService.GetAll(),
            };
            return this.View(model);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
