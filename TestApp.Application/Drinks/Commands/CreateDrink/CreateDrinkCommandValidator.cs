using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestApp.Application.Drinks.Commands.CreateDrink
{
    public class CreateDrinkCommandValidator : AbstractValidator<CreateDrinkCommand>
    {
        public CreateDrinkCommandValidator()
        {
            RuleFor(createDrinkCommand =>
                createDrinkCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(createDrinkCommand =>
               createDrinkCommand.Price).NotEmpty().LessThan(10000);
            RuleFor(createDrinkCommand =>
               createDrinkCommand.Quantity).NotEmpty().LessThan(100);
            

        }
    }
}
