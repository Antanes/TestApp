using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestApp.Application.Interfaces;
using TestApp.Domain;

namespace TestApp.Application.Drinks.Commands.DeleteDrink
{
    public class DeleteDrinkCommandHandler
        : IRequestHandler<DeleteDrinkCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteDrinkCommandHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteDrinkCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Drinks
                .FindAsync(new object[] { request.Id }, cancellationToken);
            _dbContext.Drinks.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

        }

        
    }
}
