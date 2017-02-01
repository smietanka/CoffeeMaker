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
        /// <summary>
        /// Dekoruje bazowy napoj konkretnym skladnikiem
        /// </summary>
        /// <param name="drink">Napoj dekorowany</param>
        /// <param name="comp">Skladnik jakim dekorujemy napoj.</param>
        public WithComponent(IDrink drink, Component comp)
            : base(drink)
        {
            _drink.Components.Add(comp);
        }
    }
}
