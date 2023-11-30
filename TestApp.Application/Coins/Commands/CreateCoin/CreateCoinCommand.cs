using System;
using MediatR;

namespace TestApp.Application.Coins.Commands.CreateCoin
{
    public class CreateCoinCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }        

        public int Value { get; set; }

        public bool OnClientBalance { get; set; }
       

    }
}
