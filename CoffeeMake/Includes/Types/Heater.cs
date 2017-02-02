using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class Heater : IHeater
    {
        /// <summary>
        /// Podgrzewa konkretny skladnik
        /// </summary>
        /// <param name="component">Skladnik</param>
        /// <param name="temperature">Temperatura do jakiej podgrzac</param>
        /// <returns>True jesli podgrzalo prawidlowo</returns>
        /// <exception cref="ArgumentNullException">Kiedy skladnik jest null</exception>
        /// <exception cref="ArgumentException">W momencie kiedy podana temperatura jest za niska lub skladnikiem jest skladnik suchy.</exception>
        public bool Heat(Component component, float temperature)
        {
            if(component == null)
            {
                throw new ArgumentNullException("Składnik jest nullem.");
            }

            if (temperature < 0)
            {
                throw new ArgumentException("Temperatura jest za niska.");
            }

            if(component.Type.Equals(ComponentType.DRY))
            {
                throw new ArgumentException("Suchy skladnik nie moze byc podgrzewany.");
            }
            component.Temperature = temperature;
            return true;
        }
    }
}
