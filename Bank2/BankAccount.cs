using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bank
{
    class BankAccount
    {
        private List<Transaction> AllTransactions = new List<Transaction>();

        private static UInt32 accountNumberSeed = 23232323;
        public UInt32 Number { get; }
        public string Owner { get; set; }
        private decimal balance;

        public decimal Balance
        {
            get
            {
                decimal transactionSum = 0;
                foreach (var transaction in AllTransactions)
                {
                    transactionSum += transaction.Amount;
                }
                return transactionSum + balance;
            }
            set { balance = value; }
        }

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Balance = initialBalance;
            this.Number = accountNumberSeed++;
            Console.WriteLine($"Utworzono nowe kontro z saldem: {initialBalance}");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Nie można wpłacić kwoty ujemnej.");
            }

            Transaction deposit = new Transaction(amount, date, note, "Wpłata");
            AllTransactions.Add(deposit);
            Console.WriteLine($"Dokonano wpłaty o kwocie: {amount} zł. Notka: {note} ");
        }

        public void MakeWithdraw(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Nie można wypłacić kwoty ujemnej.");
            }
            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Brak wystarczających środków na koncie.");
            }
            Transaction withdraw = new Transaction(-amount, date, note, "Wypłata");
            AllTransactions.Add(withdraw);
            Console.WriteLine($"Dokonano wypłaty o kwocie: {amount} zł. Notka: {note}");

        }
        public void TakeLoan(decimal amount, DateTime date, string note)
        {
            if(amount <=0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Nie można wziąć kredytu o takej wartości.");
            }
            if (amount > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Nie możesz wziąć więcej niz 1000 zł kredytu.");
            }
            double interestAmount = Math.Round(Convert.ToDouble(amount) * 1.32,2);
            Transaction loan = new Transaction(amount, date, note, "Kredyt");
            AllTransactions.Add(loan);
            Console.WriteLine($"Wziąłęś kredyt w kwocie {amount} zł z oprocentowaniem 32%. Notka: {note}");
            Console.WriteLine($"Kwota, którą musisz oddać to {interestAmount} zł");
        }

        public void ListTransactionHistory()
        {
            if (AllTransactions.Count == 0)
            {
                Console.WriteLine("Brak historii transakcji na koncie.");
                return;
            }

            Console.WriteLine("Historia transakcji:");
            foreach (var transaction in AllTransactions)
            {
                Console.WriteLine($"Data: {transaction.Date:dd.MM.yyyy}, Typ: {transaction.Type}, Kwota: {transaction.Amount}zł, Notka: {transaction.Note}");
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Właściciel konta: {Owner}");
            Console.WriteLine($"Numer konta: {Number}");
            Console.WriteLine($"Saldo: {Balance}");
        }
    }
}