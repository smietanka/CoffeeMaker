using CoffeeMake.Includes.Types.ComponentType;
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
        private string Name;
        public Heater()
        {
            this.Name = "Brak";
        }

        public Heater(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Nazwa jest pusta lub nullem");
            }
            this.Name = name;
        }
        public bool Heat(IComponent component, float temperature)
        {
            if (temperature < 0 || component == null)
            {
                throw new ArgumentNullException("temperatura jest za niska lub skladnik jest pusty");
            }

            if(component.GetType().IsEquivalentTo(new Dry().GetType()))
            {
                throw new ArgumentException("Suchy skladnik nie moze byc podgrzewany.");
            }
            Console.WriteLine("Poczatkowa temperatura skladnika: " + component.GetTemperature());
            Console.WriteLine(string.Format("Podgrzewam {0} na {1} stopni", component.GetName(), temperature));
            component.SetTemperature(temperature);
            Console.WriteLine("Koncowa temperatura skladnika: " + component.GetTemperature());
            return true;
        }

        public void RunJob()
        {
            throw new NotImplementedException();
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Nazwa jest pusta lub nullem");
            }
            this.Name = name;
        }

        public string GetName()
        {
            return this.Name;
        }
    }
}
