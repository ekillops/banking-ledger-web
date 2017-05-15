using Microsoft.AspNetCore.Mvc;

namespace BankingLedgerWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
