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

        public ComponentType Type { get; set; }

        public bool Grindable { get; set; }

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

        public Component(string name, ComponentType type, bool grindable)
        {
            Name = name;
            Type = type;
            Grindable = grindable;
            Temperature = 0;
        }
    }
}
