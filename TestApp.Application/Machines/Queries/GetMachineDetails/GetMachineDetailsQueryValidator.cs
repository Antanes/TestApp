using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Application.Machines.Queries.GetMachineDetails
{
    public class GetMachineDetailsQueryValidator : AbstractValidator<GetMachineDetailsQuery>
    {
        public GetMachineDetailsQueryValidator()
        {
            RuleFor(machine => machine.Id).NotEmpty();
            
        }
    
    }
}
