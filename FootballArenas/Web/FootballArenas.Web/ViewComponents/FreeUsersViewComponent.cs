namespace FootballArenas.Web.ViewComponents
{
    using FootballArenas.Services.Data.User;
    using FootballArenas.Web.ViewModels.SportComplexViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class FreeUsersViewComponent : ViewComponent
    {
        private readonly IFootballArenaUserService userService;

        public FreeUsersViewComponent(IFootballArenaUserService userService)
        {
            this.userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new SportComplexInputViewModel();
            viewModel.Users = this.userService.GetUsersWithoutSportComplex();

            return this.View(viewModel);
        }
    }
}
