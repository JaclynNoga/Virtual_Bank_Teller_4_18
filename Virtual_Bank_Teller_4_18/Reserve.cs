using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankPartnerProject
{
    class Reserve : Account
    {
        //PROPERTIES
        public override decimal AccountBalance { get; set; }
        public override DateTime Time { get; set; }
        public override int AccountNum { get; set; }
        public override string AccountType { get; set; }

        //CONSTRUCTOR
        public Reserve()
        {
            this.AccountBalance = .50M;
            this.FileName = "ReserveAccount.txt";
            this.AccountNum = TempAccountNum + 1;
            this.AccountType = "Reserve Account";
        }
    }
}
