using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApp.Domain;

namespace TestApp.Persistence.EntityTypeConfigurations
{
    public class MachineConfiguration : IEntityTypeConfiguration<Machine>
    {
        public void Configure(EntityTypeBuilder<Machine> builder)
        {
            builder.HasKey(machine => machine.Id);
            builder.HasIndex(machine => machine.Id).IsUnique();

            

        }
    }
}
