using System;
using MediatR;
using TestApp.Domain;

namespace TestApp.Application.Drinks.Commands.UpdateDrink
{
    public class UpdateDrinkCommand : IRequest
    {
        public Guid Id { get; set; }       

        public int Price { get; set; }

        public int Quantity { get; set; }
        
    }
}
