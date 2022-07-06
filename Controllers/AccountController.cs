using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
