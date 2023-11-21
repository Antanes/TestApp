using System;
using MediatR;

using Microsoft.AspNetCore.Http;

namespace TestApp.Application.Drinks.Commands.CreateDrink
{
    public class CreateDrinkCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public IFormFile? Avatar { get; set; }
    }
}
