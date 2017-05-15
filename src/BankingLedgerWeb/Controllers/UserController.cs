using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BankingLedgerWeb.Models;

namespace BankingLedgerWeb.Controllers
{
    public class UserController : Controller
    {
        User currentUser = UserHelper.CurrentUser;

        public IActionResult AccountDetails()
        {
            return View(currentUser);
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
