using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankPartnerProject
{
    class Checking : Account
    {
        //PROPERTIES
        public override decimal AccountBalance { get; set; }
        public override DateTime Time { get; set; }
        public override string FileName { get; set; }
        public override int AccountNum { get; set; }
        public override string AccountType { get; set; }

        //CONSTRUCTOR
        public Checking()
        {
            this.AccountBalance = 1000.00M;
            this.FileName = "CheckingAccount.txt";
            this.AccountNum = TempAccountNum;
            this.AccountType = "Checking Account";
        }
    }
}
