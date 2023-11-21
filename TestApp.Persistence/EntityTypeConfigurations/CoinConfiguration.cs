using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApp.Domain;

namespace TestApp.Persistence.EntityTypeConfigurations
{
    public class CoinConfiguration : IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.HasKey(coin => coin.Id);
            builder.HasIndex(coin => coin.Id).IsUnique();

            builder.Property(coin => coin.Value)
                .IsRequired();                
                        
            builder.Property(coin => coin.OnClientBalance)
                .IsRequired();

           
        }

    }
}
