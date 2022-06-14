using DomesticExpense.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomesticExpense.Infraestructure.Configurations
{
    public class ConceptConfig : IEntityTypeConfiguration<Concept>
    {
        public void Configure(EntityTypeBuilder<Concept> builder)
        {
            builder.ToTable("Concepts");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired();

            builder.Property(p => p.Category)
                   .IsRequired();
        }
    }
}
