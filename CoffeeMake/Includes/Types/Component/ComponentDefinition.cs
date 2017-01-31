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
        private string _componentName;
        public string ComponentName
        {
            get { return _componentName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Nazwa składnika jest pusta lub nullem.");
                }
                _componentName = value;
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
        /// 
        /// </summary>
        /// <param name="componentName">Składnik</param>
        /// <param name="temperature">Temperatura. Musi być większa od 0</param>
        /// <param name="amount">Ilość. Musi być większa od 0</param>
        public ComponentDefinition(string componentName, int temperature, int amount)
        {
            ComponentName = componentName;
            Temperature = temperature;
            Amount = amount;
        }
        public ComponentDefinition(string componentName, int amount)
        {
            ComponentName = componentName;
            Amount = amount;
        }
    }
}
