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

        public IActionResult Index(string filter = "day")
        {
            var transaction = _transactionService.GetAllByToFilter(filter);

            var _model = new TransactionViewModels()
            {
                Concepts = _conceptService.GetAll(),
                TransactionTypes = _transactionService.GetAllTypes(),
                Transactions = transaction,
                TotalTransactions = transaction.Sum(x => x.Amount),
                filterBy = filter
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
                PeriodMonth = (PeriodMonth)DateTime.Now.Month
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

        public IActionResult Income()
        {
            var incomes = _transactionService.GetAllIncome();
            var _model = new IncomeViewModels()
            {
                Concepts = _conceptService.GetAll(),
                TransactionTypes = _transactionService.GetAllTypes(),
                Transactions = incomes,
                TotalTransactions = incomes.Sum(x => x.Amount)
            };

            return View(_model);
        }

        [HttpPost]
        public IActionResult AddIncome(IFormCollection collection)
        {
            var transaction = new Transaction()
            {
                Date = DateTime.Parse(collection["nInputDate"].ToString()),
                Amount = double.Parse(collection["nInputAmount"].ToString()),
                Concept = _conceptService.GetById(int.Parse(collection["nSelectConcept"].ToString())),
                TransactionType = TransactionType.INGRESO,
                PeriodMonth = (PeriodMonth)DateTime.Now.Month
            };

            _transactionService.Save(transaction);

            return RedirectToAction("Income", "Transactions");
        }
    }
}
