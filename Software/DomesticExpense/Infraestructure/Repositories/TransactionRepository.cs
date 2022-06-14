﻿using DomesticExpense.Domain.Entities;
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
            return _dbContext.Transactions.ToList();
        }

        public Transaction GetById(int id)
        {
            return _dbContext.Transactions.Where(x => x.Id == id).FirstOrDefault();
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