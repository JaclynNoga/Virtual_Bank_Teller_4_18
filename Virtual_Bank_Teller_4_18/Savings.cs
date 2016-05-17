using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankPartnerProject
{
    class Savings : Account
    {
        //PROPERTIES
        public override decimal AccountBalance { get; set; }
        public override DateTime Time { get; set; }
        public override int AccountNum { get; set; }
        public override string AccountType { get; set; }

        //CONSTRUCTOR
        public Savings()
        {
            this.AccountBalance = 20.00M;
            this.FileName = "SavingsAccount.txt";
            this.AccountNum = TempAccountNum + 2;
            this.AccountType = "Savings Account";
        }
    }
}
