﻿namespace FootballArenas.Web.Areas.Administration.Controllers
{
    using FootballArenas.Common;
    using FootballArenas.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
