using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankAccount
{
    internal class BankAccount
    {
        private string ownerName;
        private decimal balance;
        private const decimal maxAmount = 1000000;
        public BankAccount(string ownerName, decimal initialBalance)
        {
            this.ownerName = ownerName;
            this.balance = initialBalance;
        }
        public string GetOwnerName()
        {
            return ownerName;
        }
        public decimal GetBalance()
        {
            return balance;
        }
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Сумма пополнения не может быть отрицательной.");
            }
            if (amount > maxAmount)
            {
                throw new ArgumentException($"Сумма пополнения не может превышать {maxAmount}.");
            }
            balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Сумма снятия не может быть отрицательной.");
            }
            if (amount > maxAmount)
            {
                throw new ArgumentException($"Сумма снятия не может превышать {maxAmount}.");
            }
            if (amount > balance)
            {
                throw new InvalidOperationException("Недостаточно средств на счёте.");
            }
            balance -= amount;
        }
    }
}
