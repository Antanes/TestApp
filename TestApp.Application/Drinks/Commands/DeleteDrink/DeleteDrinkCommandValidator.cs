using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestApp.Application.Drinks.Commands.DeleteDrink
{
    public class DeleteDrinkCommandValidator : AbstractValidator<DeleteDrinkCommand>
    {
        public DeleteDrinkCommandValidator()
        {
            RuleFor(deleteDrinkCommand =>
                deleteDrinkCommand.Id).NotEqual(Guid.Empty);



        }
    }
}
