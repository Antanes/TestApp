using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using TestApp.Application.Interfaces;
using TestApp.Domain;
using TestApp.Persistence.EntityTypeConfigurations;

namespace TestApp.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public DbSet<Domain.Machine> Machines { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Drink>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Drink>().HasData(
                new Drink { Id = Guid.NewGuid(), Name = "dsd", Quantity = 33, Price = 2, MachineId = 1 }
            );
            
            //seeding of data



            builder.Entity<Coin>().Property(x => x.Id);
            builder.Entity<Coin>().HasData(
                new Coin { Id = Guid.NewGuid(), Value = 1, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 1, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 1, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 1, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 1, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 1, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 1, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 1, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 1, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 1, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 2, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 2, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 2, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 2, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 2, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 2, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 2, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 5, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 5, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 5, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 5, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 5, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 5, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 5, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 5, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 10, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 10, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 10, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 10, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 10, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 10, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 10, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 10, Blocked = false, OnClientBalance = false, MachineId = 1 },
                new Coin { Id = Guid.NewGuid(), Value = 10, Blocked = false, OnClientBalance = false, MachineId = 1 }
            );

            builder.Entity<Domain.Machine>().Property(x => x.Id);
            builder.Entity<Domain.Machine>().HasData(
               new Domain.Machine { Id = 1 }                
            );

            builder.ApplyConfiguration(new DrinkConfiguration());
            base.OnModelCreating(builder);

            
        }

       
    }
}
