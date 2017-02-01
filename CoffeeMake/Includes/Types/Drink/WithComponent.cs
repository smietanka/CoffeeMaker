using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class WithComponent : DrinkDecorator
    {
        public WithComponent(IDrink drink, Component comp)
            : base(drink)
        {
            _drink.Components.Add(comp);
        }
    }
}
