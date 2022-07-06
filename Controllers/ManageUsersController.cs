using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementApp.Controllers
{
    public class ManageUsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
