using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlwaysForward.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class ManageUsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public IActionResult Index()
        {
            return View();
        }
    }
}
