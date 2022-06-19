using DomesticExpense.Domain.Entities;
using DomesticExpense.Infraestructure.Repositories;

namespace DomesticExpense.Domain.Services.Transactions
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public List<Transaction> GetAll()
        {
            return _transactionRepository.GetAll();
        }

        public List<Transaction> GetAllIncome()
        {
            return _transactionRepository.GetAllIncome();
        }

        public List<Transaction> GetAllByToFilter(string filter)
        {
            return _transactionRepository.GetAllByToFilter(filter);
        }

        public double GetTotalTransactionsToDay()
        {
            var transactions = _transactionRepository.GetAll();
            var sum = transactions.Sum(x => x.Amount);
            return sum;
        }

        public Transaction GetById(int id)
        {
            return _transactionRepository.GetById(id);
        }

        public void Save(Transaction transaction)
        {
            _transactionRepository.Save(transaction);
        }

        public void Update(Transaction transaction)
        {
            _transactionRepository.Update(transaction);
        }

        public void Delete(int id)
        {
            _transactionRepository.Delete(id);
        }

        public List<string> GetAllTypes()
        {
            List<string> list = new List<string>();
            foreach (var item in Enum.GetValues(typeof(TransactionType)))
            {
                list.Add(item.ToString());
            }
            return list.OrderBy(x => x).ToList();
        }
    }
}
