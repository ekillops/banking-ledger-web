using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingLedgerWeb.Models
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } // "deposit"/"withdrawal"

        public Transaction(decimal newAmount, string newDepositType)
        {
            Date = DateTime.Now;
            Amount = newAmount;
            Type = newDepositType;
        }
    }
}
