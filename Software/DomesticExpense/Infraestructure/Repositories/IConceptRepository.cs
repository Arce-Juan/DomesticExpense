using DomesticExpense.Domain.Entities;

namespace DomesticExpense.Infraestructure.Repositories
{
    public interface IConceptRepository
    {
        List<Concept> GetAll();
        Concept GetById(int id);
        List<Concept> GetByName(string name);
        void Save(Concept concept);
        void Update(Concept concept);
        void Delete(int id);
    }
}
