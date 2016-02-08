using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BankClassLibrary
{
    public class AccountClass
    {
        private decimal balance;

        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            balance -= amount;
        }

        public void TransferFunds(AccountClass destination, decimal amount)
        {
            

            if (balance - amount < minimumBalance)
                throw new InsufficientFundsException();

            destination.Deposit(amount);

            Withdraw(amount);
        }

        public decimal Balance { get { return balance; } }

        private decimal minimumBalance = 10m;
        public decimal MinimumBalance
        {
            get { return minimumBalance; }
        }

        public class InsufficientFundsException : ApplicationException
        {

        }
    }
}
