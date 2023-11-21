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
        private readonly IDrinksDbContext _dbContext;

        public BuyDrinkCommandHandler(IDrinksDbContext dbContext) =>
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
                Change();
                ChangeDenomination();
                foreach (var coin in machineQuery.Coins)
                {
                    coin.OnClientBalance = false;
                }
            }

            void Change()
            {
                machineQuery.ClientBalance -=  entity.Price;
                machineQuery.Change = machineQuery.ClientBalance;
            }

            void ChangeDenomination()
            {
                int nominal10 = 10;
                int nominal5 = 5;
                int nominal2 = 2;

                machineQuery.Coin10quantity = machineQuery.ClientBalance / nominal10;
                machineQuery.ClientBalance -= machineQuery.Coin10quantity * nominal10;

                machineQuery.Coin5quantity = machineQuery.ClientBalance / nominal5;
                machineQuery.ClientBalance -= machineQuery.Coin5quantity * nominal5;

                machineQuery.Coin2quantity = machineQuery.ClientBalance / nominal2;
                machineQuery.ClientBalance -= machineQuery.Coin2quantity * nominal2;

                machineQuery.Coin1quantity = machineQuery.ClientBalance;
                machineQuery.ClientBalance = 0;
            }

           

            await _dbContext.SaveChangesAsync(cancellationToken);


        }
       

    }
}
