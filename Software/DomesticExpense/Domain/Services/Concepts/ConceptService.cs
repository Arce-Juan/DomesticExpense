using DomesticExpense.Infraestructure.Repositories;
using DomesticExpense.Domain.Entities;

namespace DomesticExpense.Domain.Services.Concepts
{
    public class ConceptService : IConceptService
    {
        private readonly IConceptRepository _conceptRepository;

        public ConceptService(IConceptRepository conceptRepository)
        {
            _conceptRepository = conceptRepository;
        }

        public List<Concept> GetAll()
        {
            return _conceptRepository.GetAll();
        }

        public Concept GetById(int id)
        {
            return _conceptRepository.GetById(id);
        }

        public List<Concept> GetByName(string name)
        {
            return _conceptRepository.GetByName(name);
        }

        public List<string> GetAllCategory()
        {
            List<string> list = new List<string>();
            foreach (var item in Enum.GetValues(typeof(Category)))
            {
                list.Add(item.ToString());
            }
            return list.OrderBy(x => x).ToList();
        }

        public void Save(Concept concept)
        {
            _conceptRepository.Save(concept);
        }

        public void Update(Concept concept)
        {
            _conceptRepository.Update(concept);
        }

        public void Delete(int id)
        {
            _conceptRepository.Delete(id);
        }
    }
}
