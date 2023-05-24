using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class BankAccount{
        public string Number{get;}
        public string Owner { get; set; }
        public decimal Balance {
            get{
                    decimal balance = 0;
                    foreach(var item in allTransactions){
                        balance += item.Amount;
                    }
                    return balance;
                }
        }

        private static int accountNumberSeed = 1234567890;

        private List<Transaction> allTransactions = new List<Transaction>();


        public BankAccount(string name, decimal initialBalance){
            Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note){

            if(amount <=0){
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }


        public void MakeWithDrawl(decimal amount, DateTime date, string note){

            if(amount <=0){
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawl must be positive");
            }
            if (Balance - amount < 0){
                throw new InvalidOperationException("Not sufficient funds for this withdrawl");
            }
            var withdrawl = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawl);
        }

        public string GetAccountHistory(){

            var report = new StringBuilder();

            report.AppendLine("Date\t\tAmount\tNote");
            report.AppendLine("----\t\t------\t----");
            foreach(var item in allTransactions){
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
            }
            return report.ToString();
        }


    }
}