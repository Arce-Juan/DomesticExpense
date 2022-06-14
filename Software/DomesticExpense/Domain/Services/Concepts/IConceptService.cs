using DomesticExpense.Domain.Entities;

namespace DomesticExpense.Domain.Services.Concepts
{
    public interface IConceptService
    {
        List<Concept> GetAll();
        Concept GetById(int id);
        List<Concept> GetByName(string name);
        List<string> GetAllCategory();
        void Save(Concept concept);
        void Update(Concept concept);
        void Delete(int id);
    }
}
