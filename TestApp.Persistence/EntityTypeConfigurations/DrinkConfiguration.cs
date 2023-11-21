using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApp.Domain;

namespace TestApp.Persistence.EntityTypeConfigurations
{
    public class DrinkConfiguration : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            builder.HasKey(drink => drink.Id);
            builder.HasIndex(drink => drink.Id).IsUnique();

            builder.Property(drink => drink.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(drink => drink.Price)
                .IsRequired();

            builder.Property(drink => drink.Quantity)
                .IsRequired();
            

        }
        
    }
}
