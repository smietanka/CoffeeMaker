using CoffeeMake.Includes.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Interfaces.Drink
{
    public interface IDrink
    {
        Components Components { get; }
    }
}
