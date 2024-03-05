using Microsoft.AspNetCore.Mvc;

namespace InsuranceCore.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
