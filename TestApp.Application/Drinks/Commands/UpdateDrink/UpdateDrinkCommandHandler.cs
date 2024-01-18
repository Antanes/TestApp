using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Application.Interfaces;
using TestApp.Domain;

namespace TestApp.Application.Drinks.Commands.UpdateDrink
{
    public class UpdateDrinkCommandHandler : IRequestHandler<UpdateDrinkCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateDrinkCommandHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateDrinkCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Drinks.FirstOrDefaultAsync(Drink =>
                    Drink.Id == request.Id, cancellationToken);

            entity.Price = request.Price;
            entity.Quantity = request.Quantity;

            await _dbContext.SaveChangesAsync(cancellationToken);

            
        }
    }
}
