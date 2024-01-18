using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain;

namespace TestApp.Application.Drinks.Commands.CreateDrink.Factory
{
    public interface IDrinkFactory
    {
        Drink CreateDrink(string name, int price, int quantity, IFormFile? avatar);
    }
}
