using System;
using System.Reactive; 
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Application.Interfaces;
using TestApp.Domain;

namespace TestApp.Application.Coins.Commands.BlockCoin
{
    public class BlockCoinCommandHandler : IRequestHandler<BlockCoinCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public BlockCoinCommandHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(BlockCoinCommand request,
            CancellationToken cancellationToken)
        {
            var entity = _dbContext.Coins.Where(p => p.Value == request.Value);

            foreach (var coin in entity)               

            if (coin.Blocked == true) { coin.Blocked = false; } else { coin.Blocked = true; }




            await _dbContext.SaveChangesAsync(cancellationToken);

            
        }
    }
}
