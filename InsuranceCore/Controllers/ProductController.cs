using Microsoft.AspNetCore.Mvc;

namespace InsuranceCore.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
