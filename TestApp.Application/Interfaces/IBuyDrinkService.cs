using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain;

namespace TestApp.Application.Interfaces
{
    public interface IBuyDrinkService
    {
        Task BuyDrink(Guid id);
    }
}
