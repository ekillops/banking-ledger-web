using System;

namespace BankingLedgerWeb.Models
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Type { get; set; } // "deposit"/"withdrawal"

        public Transaction(decimal newAmount, string newDepositType, string newDescription = "")
        {
            Date = DateTime.Now;
            Amount = newAmount;
            Description = newDescription;
            Type = newDepositType;
        }
    }
}
