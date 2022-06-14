using DomesticExpense.Domain.Entities;

namespace DomesticExpense.Domain.Services.Transactions
{
    public interface ITransactionService
    {
        List<Transaction> GetAll();
        Transaction GetById(int id);
        void Save(Transaction transaction);
        void Update(Transaction transaction);
        void Delete(int id);
        List<string> GetAllTypes();
    }
}
