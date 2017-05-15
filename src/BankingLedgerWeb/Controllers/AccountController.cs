using Microsoft.AspNetCore.Mvc;
using BankingLedgerWeb.Models;
using BankingLedgerWeb.ViewModels;

namespace BankingLedgerWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            UserHelper.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel userInfo)
        {
            bool loginSuccessful = UserHelper.Login(userInfo.Name, userInfo.Password);

            if (loginSuccessful)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Incorrect username or password";
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(LoginViewModel userInfo)
        {
            if (!UserHelper.UserNameAvailable(userInfo.Name))
            {
                ViewBag.ErrorMessage = "Username already exists";
                return View();
            }
            else if (userInfo.Password == null || userInfo.Password == "")
            {
                ViewBag.ErrorMessage = "Please enter a password";
                return View();
            }
            else
            {
                User newUser = new User(userInfo.Name, userInfo.Password);
                UserHelper.AddNew(newUser);
                return RedirectToAction("Login");
            }
        }
    }
}
