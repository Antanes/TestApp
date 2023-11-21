using MediatR;
using TestApp.Application.Interfaces;
using TestApp.Domain;

namespace TestApp.Application.Drinks.Commands.CreateDrink
{
    public class CreateDrinkCommandHandler
        : IRequestHandler<CreateDrinkCommand, Guid>
    {
        private readonly IDrinksDbContext _dbContext;

        public CreateDrinkCommandHandler(IDrinksDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateDrinkCommand request,
            CancellationToken cancellationToken)
        {
            byte[] imageData;
            using (var binaryReader = new BinaryReader(request.Avatar.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)request.Avatar.Length);
            }
            
            var drink = new Drink
            {
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                Id = Guid.NewGuid(),
                Avatar = imageData,
                MachineId = 1

               
            };

            await _dbContext.Drinks.AddAsync(drink, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return drink.Id;
        }
    }
}
