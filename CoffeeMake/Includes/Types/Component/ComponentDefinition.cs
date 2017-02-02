using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class ComponentDefinition
    {
        private Component _component;
        public Component Component
        {
            get { return _component; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Nazwa składnika jest pusta lub nullem.");
                }
                _component = value;
            }
        }

        private int _temperature = 0;
        public int Temperature
        {
            get { return _temperature; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Ujemny parametr");
                }
                _temperature = value;
            }
        }

        private int _amount;
        public int Amount
        {
            get { return _amount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Ujemny parametr");
                }
                _amount = value;
            }
        }
        /// <summary>
        /// Tworzy obiekt definicji skladnika (dla przepisu)
        /// </summary>
        /// <param name="componentName">Nazwa skladnika</param>
        /// <param name="temperature">Temperatura skladnika na jaka podgrzac.</param>
        /// <param name="amount">Ilosc danego skladnika potrzebna do wytworzenia napoju</param>
        public ComponentDefinition(Component component, int temperature, int amount)
        {
            Component = component;
            Temperature = temperature;
            Amount = amount;
        }
        /// <summary>
        /// Tworzy obiekt definicji skladnika (dla przepisu)
        /// </summary>
        /// <param name="componentName">Nazwa skladnika</param>
        /// <param name="amount">Ilosc danego skladnika potrzebna do wytworzenia napoju</param>
        public ComponentDefinition(Component component, int amount)
        {
            Component = component;
            Amount = amount;
        }
    }
}
