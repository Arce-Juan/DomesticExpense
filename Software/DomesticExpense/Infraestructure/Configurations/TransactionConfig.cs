using DomesticExpense.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomesticExpense.Infraestructure.Configurations
{
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Amount)
                   .IsRequired();

            builder.Property(p => p.Date)
                   .IsRequired();

            builder.Property(p => p.TransactionType)
                   .IsRequired();

            builder.Property(p => p.PeriodMonth)
                   .IsRequired();
        }
    }
}
