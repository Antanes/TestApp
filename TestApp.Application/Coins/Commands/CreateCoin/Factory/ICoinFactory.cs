using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain;

namespace TestApp.Application.Coins.Commands.CreateCoin.Factory
{
    public interface ICoinFactory
    {
        Coin Create (int value);
    }
}
