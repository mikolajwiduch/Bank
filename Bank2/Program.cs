using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                playWithAccount();
            }
            catch (Exception e)
            {

                Console.WriteLine($"Coś poszło nie tak: {e.Message}");
                Console.ReadKey();
            }
        }

        static public void playWithAccount()
        {
            BankAccount bankAccount = new BankAccount("Jan Kowalski", 1000);

            bool continueLoop = true;
            while (continueLoop)
            {
                Console.Clear();
                Console.WriteLine("0 - Stwórz konto");
                Console.WriteLine("1 - Sprawdź status swojego konta");
                Console.WriteLine("2 - Dokonaj wpłaty");
                Console.WriteLine("3 - Dokonaj wypłaty");
                Console.WriteLine("4 - Historia transakcji");
                Console.WriteLine("5 - Weź kredyt");
                Console.WriteLine("6 - Zakończ");
                Console.WriteLine("Wybierz opcję (Wpisz numer na klawiaturze): ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Niestety nie ma jeszcze takiej możliwości...");
                        break;
                    case 1:
                        bankAccount.DisplayInfo();
                        break;
                    case 2:
                        Deposit(bankAccount);
                        break;
                    case 3:
                        Withdraw(bankAccount);
                        break;
                    case 4:
                        ViewTransactionHistory(bankAccount);
                        break;
                    case 5:
                        Loan(bankAccount);
                        break;
                    case 6:
                        Console.WriteLine("Dziękujmy za skorzystanie z naszego systemu bankowego :) Do zobaczenia!");
                        System.Threading.Thread.Sleep(5000);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór, wciśnij dowolny klawisz aby ponownie dokonać wyboru.");
                        continue;
                }

                Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                Console.ReadKey();
            }
        }
        // Wpłata środków na konto
        public static void Deposit(BankAccount bankAccount)
        {
            decimal amount;
            string note;
            Console.WriteLine("Podaj kwotę wpłaty:");
            amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Podaj notkę:");
            note = Console.ReadLine();
            bankAccount.MakeDeposit(amount, DateTime.Now, note);
        }
        //Wypłata środków z konta
        public static void Withdraw(BankAccount bankAccount)
        {
            decimal amount;
            string note;
            Console.WriteLine("Podaj kwotę wypłaty:");
            amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Podaj notkę:");
            note = Console.ReadLine();
            bankAccount.MakeWithdraw(amount, DateTime.Now, note);
        }
        //Sprawdzenie historii swoich transakcji
        public static void ViewTransactionHistory(BankAccount bankAccount)
        {
            bankAccount.ListTransactionHistory();
        }
        //Tworzenie nowego konta - do zrobienia
        public static void CreateAccount()
        {
            string personalData;
            decimal initialBalance;
            Console.WriteLine("Podaj imię i nazwisko:");
            personalData = Console.ReadLine();
            Console.WriteLine("Podaj kwotę początkową:");
            initialBalance = decimal.Parse(Console.ReadLine());

            BankAccount bankAccount = new BankAccount(personalData, initialBalance);
        }
        //Wzięcie kredytu
        public static void Loan(BankAccount bankAccount)
        {
            decimal amount;
            string note;
            Console.WriteLine("Podaj kwotę kredytu:");
            amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Podaj notkę:");
            note = Console.ReadLine();
            bankAccount.TakeLoan(amount, DateTime.Now, note);
        }
    }
}