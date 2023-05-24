using System;

namespace OOP // Note: actual namespace depends on the project name.
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Jitendra", 10000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with ${account.Balance}.");

            account.MakeWithDrawl(120, DateTime.Now, "Groceries");
            // Console.WriteLine(account.Balance);

            // try{
            //     account.MakeDeposit(-300, DateTime.Now, "Robbed");
            // }
            // catch (ArgumentOutOfRangeException e){
            //     Console.WriteLine("Exception caught Making negative deposit");
            //     Console.WriteLine(e.ToString());
            // }
            account.MakeWithDrawl(70, DateTime.Now, "PS5 Game");
            // Console.WriteLine(account.Balance);

            Console.WriteLine(account.GetAccountHistory());
            
        
        }
    }
}