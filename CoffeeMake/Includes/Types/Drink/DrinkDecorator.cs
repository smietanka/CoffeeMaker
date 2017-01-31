using CoffeeMake.Interfaces.Drink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public abstract class DrinkDecorator : IDrink
    {
        protected readonly IDrink _drink;
        public DrinkDecorator(IDrink drink)
        {
            this._drink = drink;
        }

        public Components Components
        {
            get { return _drink.Components; }
        }
    }
}
