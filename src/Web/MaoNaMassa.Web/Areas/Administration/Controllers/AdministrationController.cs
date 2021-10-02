namespace MaoNaMassa.Web.Areas.Administration.Controllers
{
    using MaoNaMassa.Common;
    using MaoNaMassa.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
