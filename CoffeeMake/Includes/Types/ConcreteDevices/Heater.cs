using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types.FDevices
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
                throw new ArgumentNullException("Temperatura jest za niska.");
            }

            if(component.Equals(ComponentType.DRY))
            {
                throw new ArgumentException("Suchy skladnik nie moze byc podgrzewany.");
            }

            Console.WriteLine("Poczatkowa temperatura skladnika: " + component.Temperature);
            Console.WriteLine(string.Format("Podgrzewam {0} na {1} stopni", component.Name, temperature));
            component.Temperature = temperature;
            Console.WriteLine("Koncowa temperatura skladnika: " + component.Temperature);
            return true;
        }
    }
}
