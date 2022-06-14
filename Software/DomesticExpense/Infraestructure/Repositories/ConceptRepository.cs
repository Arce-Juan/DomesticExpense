using DomesticExpense.Domain.Entities;
using DomesticExpense.Infraestructure.Contents;
using Microsoft.EntityFrameworkCore;

namespace DomesticExpense.Infraestructure.Repositories
{
    public class ConceptRepository : IConceptRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ConceptRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Concept> GetAll()
        {
            return _dbContext.Concepts
                .OrderBy(x => x.Name)
                .ToList();
        }

        public Concept GetById(int id)
        {
            return _dbContext.Concepts.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Concept> GetByName(string name)
        {
            return _dbContext.Concepts
                .Where(x => x.Name.Contains(name))
                .OrderBy(x => x.Name)
                .ToList();
        }

        public void Save(Concept concept)
        {
            _dbContext.Concepts.Add(concept);
            _dbContext.SaveChanges();
        }

        public void Update(Concept concept)
        {
            try
            {
                _dbContext.Concepts.Attach(concept);
                _dbContext.Entry(concept).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            var concept = _dbContext.Concepts.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Concepts.Remove(concept);
            _dbContext.SaveChanges();
        }
    }
}
