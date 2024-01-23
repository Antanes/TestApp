using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Application.Coins.Commands.CreateCoin
{
    public class CreateCoinCommandValidator : AbstractValidator<CreateCoinCommand>
    {
        public CreateCoinCommandValidator()
        {
            RuleFor(createCoinCommand =>
                createCoinCommand.Value).NotEmpty();
            
        }
    }
}
