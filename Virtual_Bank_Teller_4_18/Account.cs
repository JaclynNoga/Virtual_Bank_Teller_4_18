using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankPartnerProject
{
    class Account
    {
        //FIELDS
        private decimal accountBalance;
        private DateTime time = new DateTime();
        private int accountNum;
        private string fileName;
        private int tempAccountNum;
        private string accountType;
        private Random rand = new Random();


        //PROPERTIES
        public virtual decimal AccountBalance { get; set; }
        public virtual DateTime Time { get; set; }
        public virtual string FileName { get; set; }
        public virtual int AccountNum { get; set; }
        public int TempAccountNum { get; set; }
        public virtual string AccountType { get; set; }


        //METHODS
        public decimal Withdraw()
        {
            decimal tempAmount = 0.00M;

            Console.WriteLine("Enter withdraw amount: ");
            while (!decimal.TryParse(Console.ReadLine(), out tempAmount) ||
                   tempAmount <= 0 ||   //checks if the amount the user entered is less than or equal to 0
                   tempAmount.ToString().IndexOf('.') != tempAmount.ToString().Length - 3)  //checks if amount is in the right format #.##
            {
                Console.WriteLine("Please enter a valid amount");
            }
            tempAmount = OverdraftChecker(tempAmount);

            this.AccountBalance -= tempAmount;
            this.Time = DateTime.Now;

            return tempAmount;
        }
        public decimal Deposit()
        {
            decimal tempAmount = 0.00M;

            Console.WriteLine("Enter deposit amount: ");
            while (!decimal.TryParse(Console.ReadLine(), out tempAmount) ||
                   tempAmount <= 0 ||   //checks if the amount the user entered is less than or equal to 0
                   tempAmount.ToString().IndexOf('.') != tempAmount.ToString().Length - 3)  //checks if amount is in the right format #.##
            {
                Console.WriteLine("Please enter a valid amount");
            }
            this.AccountBalance += tempAmount;
            this.Time = DateTime.Now;

            return tempAmount;
        }

        public decimal OverdraftChecker(decimal amount)     //returns the amount that will be withdrawn from the account
        {
            if (amount <= this.AccountBalance)  //if user wants to withdraw a valid amount
            {
                return amount;
            }
            else         //user wants to withdraw more than amount in the account
            {
                Console.WriteLine("Transaction cancelled. Insufficient funds.");
                Console.ReadKey();
                return 0.00M;
            }
        }
        public int RandomGenerator()    //returns some 5 digit number
        {
            int randAccountNum = rand.Next(10000, 99999);
            return randAccountNum;
        }

        //CONSTRUCTOR
        public Account()
        {
            this.TempAccountNum = RandomGenerator();
        }
    }
}