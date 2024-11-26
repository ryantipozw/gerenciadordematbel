using Microsoft.AspNetCore.Mvc;

namespace FrangoZe.Web.Controllers
{
    public class ResumoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
