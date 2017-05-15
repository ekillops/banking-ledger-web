using System.Collections.Generic;
using System.Linq;

namespace BankingLedgerWeb.Models
{
    public class BankAccount
    {
        decimal Balance;
        List<Transaction> Transactions { get; set; }

        public BankAccount()
        {
            Balance = 0;
            Transactions = new List<Transaction>();
        }

        public bool Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Transactions.Add(new Transaction(amount, "deposit"));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Transactions.Add(new Transaction(amount, "withdrawal"));
                return true;
            }
            else
            {
                return false;
            }
        }

        public decimal GetBalance()
        {
            return Balance;
        }

        public List<Transaction> GetTransactionHistory()
        {
            return Transactions.OrderByDescending(t => t.Date).ToList();
        }
    }
}
