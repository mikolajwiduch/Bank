using System;

namespace Bank
{
    class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Note { get; }
        public string Type { get; }

        public Transaction(decimal amount, DateTime date, string note, string transactionType)
        {
            this.Amount = amount;
            this.Date = date;
            this.Note = note;
            this.Type = transactionType;

        }
    }
}