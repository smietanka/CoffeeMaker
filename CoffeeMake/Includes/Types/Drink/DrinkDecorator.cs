using CoffeeMake.Interfaces;
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
        /// <summary>
        /// Bazowy konstruktor.
        /// </summary>
        /// <param name="drink">Napoj ktory bedzie dekorowany</param>
        public DrinkDecorator(IDrink drink)
        {
            if(drink == null)
            {
                throw new ArgumentNullException("napoj jest nullem");
            }
            this._drink = drink;
        }

        public Components Components
        {
            get { return _drink.Components; }
        }
    }
}
