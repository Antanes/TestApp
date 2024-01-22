using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Application.Drinks.Commands.BuyDrink;
using TestApp.Application.Interfaces;
using TestApp.Domain;

namespace TestApp.Application.Drinks.Commands.BuyDrink
{
    public class BuyDrinkCommandHandler : IRequestHandler<BuyDrinkCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public BuyDrinkCommandHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(BuyDrinkCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Drinks
                .FindAsync(new object[] { request.Id }, cancellationToken);

            var machineQuery = await _dbContext.Machines.FindAsync(1);
            machineQuery.Coins = await _dbContext.Coins.ToListAsync();
                     
            machineQuery.Change = 0;
            machineQuery.Coin1quantity = 0;
            machineQuery.Coin2quantity = 0;
            machineQuery.Coin5quantity = 0;
            machineQuery.Coin10quantity = 0;

            if (entity.Quantity > 0 && entity.Price <= machineQuery.ClientBalance)
            {
                entity.Quantity--;
                machineQuery.Change = machineQuery.CalculateChange(machineQuery.ClientBalance, entity.Price);
                machineQuery.DenominationChange = machineQuery.CalculateDenominations(machineQuery.Change);
                machineQuery.Coin1quantity = machineQuery.DenominationChange[1];
                machineQuery.Coin2quantity = machineQuery.DenominationChange[2];
                machineQuery.Coin5quantity = machineQuery.DenominationChange[5];
                machineQuery.Coin10quantity = machineQuery.DenominationChange[10];
                foreach (var coin in machineQuery.Coins)
                {
                    coin.OnClientBalance = false;
                }
                machineQuery.ClientBalance = 0;
            }

           

            await _dbContext.SaveChangesAsync(cancellationToken);


        }
       

    }
}
