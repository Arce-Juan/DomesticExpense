using DomesticExpense.Domain.Entities;

namespace DomesticExpense.Domain.Services.Concepts
{
    public interface IConceptService
    {
        List<Concept> GetAll();
        Concept GetById(int id);
        Concept GetByName(string name);
        List<string> GetAllCategory();
    }
}
