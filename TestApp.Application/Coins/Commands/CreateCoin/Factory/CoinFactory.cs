using Azure.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Application.Drinks.Commands.CreateDrink.Factory;
using TestApp.Domain;

namespace TestApp.Application.Coins.Commands.CreateCoin.Factory
{
    public class CoinFactory : ICoinFactory
    {
        public Coin Create(int value)
        {
            return new Coin
            {
                Value = value,
                OnClientBalance = true,
                Blocked = false,
                Id = Guid.NewGuid(),
                MachineId = 1
            };
        }
    }
}
