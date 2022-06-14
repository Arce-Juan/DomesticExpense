using DomesticExpense.Domain.Entities;

namespace DomesticExpense.Models
{
    public class ConceptViewModels
    {
        public List<Concept> Concepts { get; set; }
        public List<string> Categories { get; set; }
    }

}
