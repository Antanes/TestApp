using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestApp.Application.Interfaces;

namespace TestApp.Application.Services
{
    public class BuyDrinkService : IBuyDrinkService
    {
        private readonly IApplicationDbContext _dbContext;
        public BuyDrinkService(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task BuyDrink(Guid id)
        {
            var entity = await _dbContext.Drinks
                .FindAsync(new object[] { id });

            var machineQuery = await _dbContext.Machines.FirstOrDefaultAsync(m => m.Id == 1);
            machineQuery.Coins = await _dbContext.Coins.ToListAsync();

            machineQuery = machineQuery.Reset(machineQuery);

            if (entity.Quantity > 0 && entity.Price <= machineQuery.ClientBalance)
            {
                entity.Quantity--;
                machineQuery.Change = machineQuery.CalculateChange(machineQuery.ClientBalance, entity.Price);
                machineQuery = machineQuery.CalculateDenominations(machineQuery, machineQuery.Change);

               
                machineQuery.ClientBalance = 0;
            }

            await _dbContext.SaveChangesAsync(default(CancellationToken));

        }
    }
}
