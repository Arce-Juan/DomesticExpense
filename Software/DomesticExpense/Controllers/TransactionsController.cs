using DomesticExpense.Domain.Entities;
using DomesticExpense.Domain.Services.Concepts;
using DomesticExpense.Domain.Services.Transactions;
using DomesticExpense.Models;
using Microsoft.AspNetCore.Mvc;

namespace DomesticExpense.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IConceptService _conceptService;

        public TransactionsController(ITransactionService transactionService, IConceptService conceptService)
        {
            _transactionService = transactionService;
            _conceptService = conceptService;
        }

        public IActionResult Index()
        {
            var transaction = _transactionService.GetAllByToDay();
            var _model = new TransactionViewModels()
            {
                Concepts = _conceptService.GetAll(),
                TransactionTypes = _transactionService.GetAllTypes(),
                Transactions = transaction,
                TotalTransactions = transaction.Sum(x => x.Amount)
            };

            return View(_model);
        }

        [HttpPost]
        public IActionResult AddTransaction(IFormCollection collection)
        {
            var transaction = new Transaction()
            {
                Date = DateTime.Parse(collection["nInputDate"].ToString()),
                Amount = double.Parse(collection["nInputAmount"].ToString()),
                Concept = _conceptService.GetById(int.Parse(collection["nSelectConcept"].ToString())),
                TransactionType = TransactionType.EGRESO,
                PeriodMonth = PeriodMonth.AGOSTO
            };

            _transactionService.Save(transaction);

            return RedirectToAction("Index", "Transactions", new { filter = "" });
        }

        public IActionResult Create()
        {
            var _model = new CreateTransactionViewModels()
            {
                Concepts = _conceptService.GetAll(),
                TransactionTypes = _transactionService.GetAllTypes(),
            };

            return View(_model);
        }
    }
}
