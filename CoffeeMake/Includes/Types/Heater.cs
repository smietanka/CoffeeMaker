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
