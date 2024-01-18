using Azure.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain;

namespace TestApp.Application.Drinks.Commands.CreateDrink.Factory
{
    public class DrinkFactory : IDrinkFactory
    {
        public Drink CreateDrink(string name, int price, int quantity, IFormFile? avatar)
        {
            byte[] imageData;
            if (avatar != null)
            {
                using (var binaryReader = new BinaryReader(avatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)avatar.Length);
                }
            }
            else
            {
                imageData = new byte[0]; 
            }
            return new Drink
            {
                Name = name,
                Price = price,
                Quantity = quantity,                
                Id = Guid.NewGuid(),
                Avatar = imageData,
                MachineId = 1
            };
        }
    }
}
