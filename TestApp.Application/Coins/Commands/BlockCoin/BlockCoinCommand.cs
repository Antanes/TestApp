using System;
using MediatR;

namespace TestApp.Application.Coins.Commands.BlockCoin
{
    public class BlockCoinCommand : IRequest
    {
        public int Value { get; set; }

       

    }
}
