using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestApp.Application.Coins.Commands.CreateCoin.Factory;
using TestApp.Application.Interfaces;
using TestApp.Domain;

namespace TestApp.Application.Coins.Commands.CreateCoin
{
    public class CreateCoinCommandHandler
        : IRequestHandler<CreateCoinCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICoinFactory _coinFactory;
        public CreateCoinCommandHandler(ICoinFactory coinFactory, IApplicationDbContext dbContext)
        { _dbContext = dbContext; _coinFactory = coinFactory; }

        public async Task<Guid> Handle(CreateCoinCommand request,
            CancellationToken cancellationToken)
        {
            var coin = _coinFactory.Create(request.Value);
            await _dbContext.Coins.AddAsync(coin, cancellationToken);

            var machine = _dbContext.Machines.FirstOrDefault(m => m.Id == 1);
            machine.CoinInsert(request.Value);
            //machine.ClientBalance += request.Value;
            request.Value = machine.ClientBalance;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return coin.Id;
        }
    }
}
