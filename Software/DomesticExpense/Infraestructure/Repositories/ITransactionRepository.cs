using DomesticExpense.Domain.Entities;

namespace DomesticExpense.Infraestructure.Repositories
{
    public interface ITransactionRepository
    {
        List<Transaction> GetAll();
        List<Transaction> GetAllByToFilter(string filter);
        Transaction GetById(int id);
        void Save(Transaction transaction);
        void Update(Transaction transaction);
        void Delete(int id);

    }
}
