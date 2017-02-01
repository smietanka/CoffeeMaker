using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class Component
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Nazwa jest pusta lub nullem.");
                }
                _name = value;
            }
        }

        public ComponentType Type { get; private set; }

        public bool Grindable { get; private set; }

        private float _temperature;
        public float Temperature
        {
            get { return _temperature; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Temperatura jest za niska");
                }
                _temperature = value;
            }
        }
        /// <summary>
        /// Tworzy obiekt skladnika z domyslna zerowa temperatura.
        /// </summary>
        /// <param name="name">Nazwa składnika</param>
        /// <param name="type">Typ składnika</param>
        /// <param name="grindable">Czy jest składnik mielony.</param>
        public Component(string name, ComponentType type, bool grindable)
        {
            Name = name;
            Type = type;
            Grindable = grindable;
            Temperature = 0;
        }
    }
}
