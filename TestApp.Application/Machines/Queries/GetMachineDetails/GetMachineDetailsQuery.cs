using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestApp.Application.Machines.Queries.GetMachineDetails
{
    public class GetMachineDetailsQuery : IRequest<MachineDetailsVm>
    {
        public int Id { get; set; }
        public int Pass { get; set; }
        public bool Logoff { get; set; }
    }
}
