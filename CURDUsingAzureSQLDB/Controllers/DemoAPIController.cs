using Microsoft.AspNetCore.Mvc;

namespace CURDUsingAzureSQLDB.Controllers
{
    public class DemoAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
