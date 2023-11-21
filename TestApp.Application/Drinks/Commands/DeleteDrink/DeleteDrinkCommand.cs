using System;
using MediatR;

namespace TestApp.Application.Drinks.Commands.DeleteDrink
{
    public class DeleteDrinkCommand : IRequest
    {
        public Guid Id { get; set; }

        


    }
}