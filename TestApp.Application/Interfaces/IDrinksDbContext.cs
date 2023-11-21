using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestApp.Domain;
namespace TestApp.Application.Interfaces
{
    public interface IDrinksDbContext
    {
        DbSet<Drink> Drinks { get; set; }
        DbSet<Coin> Coins { get; set; }
        DbSet<Machine> Machines { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
