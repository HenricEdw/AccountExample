using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //För att kunna skapa en kontoinstans behöver jag en personinstans att skicka in i accountkonstruktorn
            Person person = new Person("Henric", "1122334455");

            //Så använder jag personinstansen för att skicka in i accountkonstruktorn
            Account account = new Account(person);

            account.Deposit(2000);
            PrintAccountInfo(account);

            account.Withdraw(400);
            PrintAccountInfo(account);

            decimal interestAmount = account.CalculateInterestForAccount();
            PrintAccountInfo(account);
            Console.WriteLine($"{account.AccountHolder.Name}s konto fick {interestAmount}:- i ränta.");

            decimal newRate = account.ChangeInterestRate(0.04M);
            PrintAccountInfo(account);
            Console.WriteLine($"Ny ränta är {newRate} som ska stämma med kontots instansvariabel {account.InterestRate}");

            Console.ReadLine();
            
        }

        public static void PrintAccountInfo(Account account)
        {
            Console.WriteLine($"{account.AccountHolder.Name}s konto har nu {account.Amount}:-");
        }
    }
}
