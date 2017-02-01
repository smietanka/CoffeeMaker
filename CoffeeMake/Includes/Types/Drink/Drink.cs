using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class Drink : IDrink
    {
        private Components _components;
        /// <summary>
        /// Inicjalizuje pusta liste skladnikow napoju.
        /// </summary>
        public Drink()
        {
            _components = new Components();
        }
        public Components Components
        {
            get { return _components; }
        }
    }
}
