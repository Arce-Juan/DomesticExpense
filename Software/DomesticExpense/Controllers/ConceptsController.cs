using DomesticExpense.Domain.Entities;
using DomesticExpense.Domain.Services.Concepts;
using DomesticExpense.Models;
using Microsoft.AspNetCore.Mvc;

namespace DomesticExpense.Controllers
{
    public class ConceptsController : Controller
    {
        private readonly IConceptService _conceptService;

        public ConceptsController(IConceptService conceptService)
        {
            _conceptService = conceptService;
        }

        public IActionResult Index(string filter = "")
        {
            var _model = new ConceptViewModels()
            {
                Concepts = filter != "" ? _conceptService.GetByName(filter) : _conceptService.GetAll(),
                Categories = _conceptService.GetAllCategory()
            };

            return View(_model);
        }

        [HttpPost]
        public IActionResult SerchConceptByName(IFormCollection collection)
        {
            var filter = collection["searchText"].ToString();
            return RedirectToAction("Index", "Concepts", new { filter = filter });
        }

        [HttpPost]
        public IActionResult AddConcept(IFormCollection collection)
        {
            var concept = new Concept()
            {
                Name = collection["idInputName"].ToString().ToUpper(),
                Category = (Category)Enum.Parse(typeof(Category), collection["nSelectCategory"].ToString())
            };

            _conceptService.Save(concept);

            return RedirectToAction("Index", "Concepts", new { filter = "" });
        }
    }
}
