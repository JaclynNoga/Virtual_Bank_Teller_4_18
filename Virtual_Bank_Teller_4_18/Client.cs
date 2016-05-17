using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankPartnerProject
{
    class Client
    {
        //FIELDS
        private string clientName;

        //PROPERTIES
        public string ClientName { get; set; }

        //METHOD
        public string GetName()
        {
            string name = "";
            while (name == "")  //loops until user enters a name
            {
                Console.WriteLine("\nEnter your full name:");
                name = Console.ReadLine();
            }
            return name;
        }

        //CONSTRUCTOR
        public Client()
        {
            this.ClientName = GetName();
        }
    }
}
