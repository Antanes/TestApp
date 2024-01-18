using MediatR;
using TestApp.Application.Drinks.Commands.CreateDrink.Factory;
using TestApp.Application.Interfaces;
using TestApp.Domain;

namespace TestApp.Application.Drinks.Commands.CreateDrink
{
    public class CreateDrinkCommandHandler
        : IRequestHandler<CreateDrinkCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IDrinkFactory _drinkFactory;

        public CreateDrinkCommandHandler(IDrinkFactory drinkFactory, IApplicationDbContext dbContext) 
            {_dbContext = dbContext; _drinkFactory = drinkFactory; }

        public async Task<Guid> Handle(CreateDrinkCommand request,
            CancellationToken cancellationToken)
        {
            var drink = _drinkFactory.CreateDrink(request.Name, request.Price, request.Quantity, request.Avatar);

            await _dbContext.Drinks.AddAsync(drink, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return drink.Id;
        }
    }
}
