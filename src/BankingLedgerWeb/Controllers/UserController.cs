using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankingLedgerWeb.Models;
using BankingLedgerWeb.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BankingLedgerWeb.Controllers
{
    public class UserController : Controller
    {
        User currentUser = UserHelper.CurrentUser;
        public IActionResult AccountDetails()
        {
            return View(currentUser);
        }

        public IActionResult TransactionHistory()
        {
            List<Transaction> transactions = currentUser.BankAccount.GetTransactionHistory();
            return View();
        }

        public IActionResult Deposit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Deposit(float inputAmount)
        {
            decimal depositAmount = Convert.ToDecimal(inputAmount);
            bool depositSuccessful = currentUser.BankAccount.Deposit(depositAmount);

            if (depositSuccessful)
            {
                ViewBag.StatusMessage = "Deposit sucessful";
                ViewBag.OperationSuccessful = true;
            }
            else
            {
                ViewBag.StatusMessage = "Deposit unsuccessful. Please enter a positive number";
                ViewBag.OperationSuccessful = false;
            }
            return View("AccountDetails", currentUser);
        }

        public IActionResult Withdraw()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Withdraw(float inputAmount)
        {
            decimal withdrawAmount = Convert.ToDecimal(inputAmount);
            bool withdrawalSuccessful = currentUser.BankAccount.Withdraw(withdrawAmount);

            if (withdrawalSuccessful)
            {
                ViewBag.StatusMessage = "Withdrawal sucessful";
                ViewBag.OperationSuccessful = true;
            }
            else
            {
                ViewBag.StatusMessage = "Withdrawal unsuccessful. Enter a positive number less than your account balance";
                ViewBag.OperationSuccessful = false;
            }

            return View("AccountDetails", currentUser);
        }
    }
}
