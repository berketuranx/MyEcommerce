using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC_MyProject.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize]
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
    }
}
