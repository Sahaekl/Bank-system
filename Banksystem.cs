using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    class BankAccount
    {
        public string AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public decimal Balance { get;  private set; }
        public DateTime createdDate { get; set; }

        public BankAccount(string accountNumber, string ownerName, decimal balacne, DateTime CreatedDate)
        {
            this.AccountNumber = accountNumber;
            this.OwnerName = ownerName;
            this.Balance = balacne;
            this.createdDate = CreatedDate;

        }

         public virtual void DepositMoney(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Amount must be greater than zero.");
            }
            else
            {
                Balance += amount;
            }


        }

         public virtual void WithdrawMoney(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Amount must be greater than zero.");
            }
            else if (amount > Balance)
            {
                Console.WriteLine("Insufficient balance.");
            }
            else
            {
                Balance -= amount;
            }
        }
        protected void AddToBalance(decimal amount)
        {
            Balance += amount;
        }
        protected void SubtractFromBalance(decimal amount)
        {
            Balance -= amount;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Owner Name: {OwnerName}");
            Console.WriteLine($"Balance: {Balance}");
            Console.WriteLine($"Created Date: {createdDate}");

        }
    }

    class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountNumber, string ownerName, decimal balacne, DateTime CreatedDate) : base(accountNumber, ownerName, balacne, CreatedDate)
        {

        }
        public void AddMonthly()
        {
            AddToBalance(Balance * 0.05m);
        }

    }
    class CurrentAccount : BankAccount
    {
        public CurrentAccount(string accountNumber, string ownerName, decimal balacne, DateTime CreatedDate) : base(accountNumber, ownerName, balacne, CreatedDate)
        {

        }
        public override void WithdrawMoney(decimal amount)
        {

            if (amount <= 0)
            {
                Console.WriteLine("Amount must be greater than zero.");
            }
           else  if (amount + 10 > Balance)
            {
                Console.WriteLine("Insufficient balance.");
            }
            else
            {
                SubtractFromBalance(amount + 10);
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount s1 = new SavingsAccount("1AC" , "roaa" , 1223m , DateTime.Now);
            s1.DepositMoney(1000);
            s1.WithdrawMoney(20);
            s1.AddMonthly();
            s1.DisplayDetails();

            CurrentAccount c1 = new CurrentAccount(
                "1AC2",
                "Ahmed",
                1000m,
                DateTime.Now
            );

            c1.DepositMoney(500);
            c1.WithdrawMoney(200);
            c1.DisplayDetails();


        }
    }
}

