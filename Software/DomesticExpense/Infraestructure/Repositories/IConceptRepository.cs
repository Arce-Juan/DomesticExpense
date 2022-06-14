using DomesticExpense.Domain.Entities;

namespace DomesticExpense.Infraestructure.Repositories
{
    public interface IConceptRepository
    {
        List<Concept> GetAll();
        Concept GetById(int id);
        Concept GetByName(string name);
    }
}
