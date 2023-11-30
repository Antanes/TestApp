using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestApp.Application.Interfaces;
using TestApp.Domain;

namespace TestApp.Application.Coins.Commands.CreateCoin
{
    public class CreateCoinCommandHandler
        : IRequestHandler<CreateCoinCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateCoinCommandHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateCoinCommand request,
            CancellationToken cancellationToken)
        {
            var coin = new Coin
            {
                Value = request.Value,
                OnClientBalance = true,  
                Blocked = false,
                Id = Guid.NewGuid(),
                MachineId = 1
            };
            await _dbContext.Coins.AddAsync(coin, cancellationToken);


            var machine = await _dbContext.Machines.FindAsync(1);
           
            machine.ClientBalance += request.Value;

            request.Value = machine.ClientBalance;

             await _dbContext.SaveChangesAsync(cancellationToken);

            return coin.Id;
        }
    }
}
