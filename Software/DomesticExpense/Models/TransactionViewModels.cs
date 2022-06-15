using DomesticExpense.Domain.Entities;

namespace DomesticExpense.Models
{
    public class TransactionViewModels
    {
        public List<Concept> Concepts { get; set; }
        public List<string> TransactionTypes { get; set; }
        public List<Transaction> Transactions { get; set; }
        public double TotalTransactions { get; set; }

    }

    public class CreateTransactionViewModels
    {
        public List<Concept> Concepts { get; set; }
        public List<string> TransactionTypes { get; set; }
    }
}
