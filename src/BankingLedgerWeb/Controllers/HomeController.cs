using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankingLedgerWeb.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BankingLedgerWeb.Controllers
{
    public class HomeController : Controller
    {
        UserHelper userHelper = new UserHelper();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
