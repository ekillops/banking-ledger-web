using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingLedgerWeb.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } // username rather than first or last
        public string Password { get; set; }
        public BankAccount BankAccount { get; set; }

        public User(string newName, string newPassword)
        {
            Id = 0;
            Name = newName;
            Password = newPassword;
            BankAccount = new BankAccount();
        }
    }
}
