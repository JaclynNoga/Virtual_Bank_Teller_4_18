using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BankPartnerProject;

namespace ParamObjectArray4_18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bank!");

            Client client = new Client();

            Checking checkingAccount = new Checking();
            Reserve reserveAccount = new Reserve();
            Savings savingsAccount = new Savings();

            StreamWriter cWriter = new StreamWriter("CheckingAccount.txt");
            StreamWriter sWriter = new StreamWriter("SavingsAccount.txt");
            StreamWriter rWriter = new StreamWriter("ReserveAccount.txt");

            StartFile(client.ClientName, cWriter, checkingAccount);
            StartFile(client.ClientName, sWriter, savingsAccount);
            StartFile(client.ClientName, rWriter, reserveAccount);

            bool redo = true;
            do
            {
                Console.Clear();
                Console.WriteLine("{0}'s Accounts", client.ClientName);
                Console.WriteLine();
                Console.WriteLine("1. Checking \n2. Savings \n3. Reserve \n4. Exit the bank");
                int account = 0;
                int.TryParse(Console.ReadLine(), out account);
                switch (account)
                {
                    case 1:
                        Big(checkingAccount, cWriter, client, redo);
                        break;
                    case 2:
                        Big(savingsAccount, sWriter, client, redo);
                        break;
                    case 3:
                        Big(reserveAccount, rWriter, client, redo);
                        break;
                    case 4:
                        Console.WriteLine("\nThank you for your patronage");
                        redo = false;
                        break;
                    default:
                        break;
                }

            }
            while (redo);

            cWriter.Close();
            sWriter.Close();
            rWriter.Close();
        }

        static void StartFile(string fullName, StreamWriter name, Account temp)
        {
            name.WriteLine(fullName);
            name.WriteLine(temp.AccountType);
            name.WriteLine($"Account # {temp.AccountNum}");
            name.WriteLine();
            name.WriteLine("Date \t  Time \t\t +/- \t Amount \t New Balance");
        }

        static void Big(Account temp, StreamWriter writer, Client client, bool redo)
        {
            bool redo2 = true;

            do
            {
                Console.Clear();
                Console.WriteLine(temp.AccountType);
                Console.WriteLine();
                Console.WriteLine("1. View Client Information\n2. View Account Balance\n3. Deposit Funds\n4. Withdraw Funds\n5. Access another account or Exit");
                int answer = 0;     //initialized here so if try parse doesn't work the switch case will go to default
                int.TryParse(Console.ReadLine(), out answer);
                Console.Clear();
                switch (answer)
                {
                    case 1: //view client info
                        Console.WriteLine("Name: {0}\nAccount Number: {1}", client.ClientName, temp.AccountNum);
                        Console.ReadKey();
                        break;
                   
                    case 2: //view account balance
                        Console.WriteLine($"${temp.AccountBalance}");
                        Console.ReadKey();
                        break;
                    
                    case 3: //deposit funds
                        decimal deposit = temp.Deposit();
                        writer.WriteLine($"{temp.Time} \t + \t ${deposit}  \t ${temp.AccountBalance}");
                        break;

                    case 4: //withdraw funds
                        decimal withdrawal = temp.Withdraw();
                        writer.WriteLine($"{temp.Time} \t - \t ${withdrawal}  \t ${temp.AccountBalance}");
                        break;
                    case 5: //exits specific account back to main menu
                        redo2 = false;
                        break;
                    default:    //error with input
                        Console.WriteLine("Please try again");
                        Console.ReadKey();
                        break;
                }
            }
            while (redo2);
        }
    }
}
