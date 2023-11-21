using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Application.Drinks.Commands.BuyDrink
{
    public class BuyDrinkCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
