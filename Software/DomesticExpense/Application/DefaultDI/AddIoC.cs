using DomesticExpense.Domain.Services.Concepts;
using DomesticExpense.Domain.Services.Transactions;
using DomesticExpense.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DomesticExpense.Application.DefaultDI
{
    public static class AddIoC
    {
        public static IServiceCollection AddInversionOfControl(this IServiceCollection services)
        {
            services.AddTransient<IConceptService, ConceptService>();
            services.AddTransient<IConceptRepository, ConceptRepository>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            
            return services;
        }

    }
}
