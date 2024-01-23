using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Application.Coins.Commands.BlockCoin;

namespace TestApp.Application.Coins.Commands.BlockCoin
{
    public class BlockCoinCommandValidator : AbstractValidator<BlockCoinCommand>
    {
        public BlockCoinCommandValidator()
        {
            RuleFor(blockCoinCommand =>
                blockCoinCommand.Value).NotEmpty();

        }
    }
}
