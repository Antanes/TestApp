using System;
using MediatR;

namespace TestApp.Application.Coins.Commands.CreateCoin
{
    public class CreateCoinCommand : IRequest<Guid>
    {
              

        public int Value { get; set; }

        
       

    }
}
