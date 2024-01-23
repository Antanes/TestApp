using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestApp.Application.Drinks.Commands.UpdateDrink
{
    public class UpdateDrinkCommandValidator : AbstractValidator<UpdateDrinkCommand>
    {
        public UpdateDrinkCommandValidator()
        {
            RuleFor(deleteDrinkCommand =>
                deleteDrinkCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateDrinkCommand =>
               updateDrinkCommand.Price).NotEmpty().LessThan(10000);
            RuleFor(updateDrinkCommand =>
               updateDrinkCommand.Quantity).NotEmpty().LessThan(100);


        }
    }
}
