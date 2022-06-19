using DomesticExpense.Domain.Entities;
using DomesticExpense.Infraestructure.Contents;
using Microsoft.EntityFrameworkCore;

namespace DomesticExpense.Infraestructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Transaction> GetAll()
        {
            return _dbContext.Transactions
                .Include(x => x.Concept)
                .OrderByDescending(x => x.Date)
                .ToList();
        }

        public List<Transaction> GetAllIncome()
        {
            return _dbContext.Transactions
                .Include(x => x.Concept)
                .Where(x => x.TransactionType == TransactionType.INGRESO)
                .OrderByDescending(x => x.Date)
                .ToList();
        }

        public List<Transaction> GetAllByToFilter(string filter)
        {
            if (filter == "day")
                return _dbContext.Transactions
                    .Include(x => x.Concept)
                    .Where(x => x.TransactionType == TransactionType.EGRESO && x.Date.Date == DateTime.Now.Date)
                    .OrderByDescending(x => x.Date)
                    .OrderByDescending(x => x.Id)
                    .ToList();
            else
                return _dbContext.Transactions
                    .Include(x => x.Concept)
                    .Where(x => x.TransactionType == TransactionType.EGRESO && x.Date.Month == DateTime.Now.Month)
                    .OrderByDescending(x => x.Date)
                    .OrderByDescending(x => x.Id)
                    .ToList();
        }

        public Transaction GetById(int id)
        {
            return _dbContext.Transactions.Where(x => x.Id == id)
                .Include(x => x.Concept)
                .FirstOrDefault();
        }

        public void Save(Transaction transaction)
        {
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
        }

        public void Update(Transaction transaction)
        {
            try
            {
                _dbContext.Transactions.Attach(transaction);
                _dbContext.Entry(transaction).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            var transaction = _dbContext.Transactions.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Transactions.Remove(transaction);
            _dbContext.SaveChanges();
        }
    }
}
