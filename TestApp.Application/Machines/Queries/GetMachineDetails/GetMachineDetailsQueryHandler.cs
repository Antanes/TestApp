using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TestApp.Application.Interfaces;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Domain;
using TestApp.Application.Machines.Queries.GetMachineDetails;


namespace TestApp.Application.Machines.Queries.GetMachineDetails
{
    public class GetMachineDetailsQueryHandler
        : IRequestHandler<GetMachineDetailsQuery, MachineDetailsVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMachineDetailsQueryHandler(IApplicationDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<MachineDetailsVm> Handle(GetMachineDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Machines
                .FirstOrDefaultAsync(machine =>
                machine.Id == 1, cancellationToken);
            entity.MachineState = Machine.State.IdleState;
            if (request.Logoff == true) { entity.Login = false; }
            if (request.Pass == 123456) { entity.Login = true; }
            await _dbContext.SaveChangesAsync(cancellationToken);

            entity.Drinks = await _dbContext.Drinks.ToListAsync();
            entity.Coins = await _dbContext.Coins.ToListAsync();

            return _mapper.Map<MachineDetailsVm>(entity);
        }
    }
    
    
}
