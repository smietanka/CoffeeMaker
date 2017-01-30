using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types.FDevices
{
    public class Tank : ITank
    {
        private float _capacity;
        public float Capacity
        {
            get { return _capacity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Pojemnosc zbiornika mniejsza od 0");
                }
                _capacity = value;
            }
        }

        private Component _component;
        public Component Component
        {
            get { return _component; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Składnik jest nullem.");
                }
                _component = value;
            }
        }

        public Tank(float capacity, Component component)
        {
            Capacity = capacity;
            Component = component;
        }

        public void RemoveContent(float content)
        {
            if (Capacity - content < 0)
            {
                throw new ArgumentException("Za duzo chcesz pobrac zawartosci.");
            }
            if (content < 0)
            {
                throw new ArgumentException("Wpisana ilość jest za mała.");
            }
            Capacity -= content;
        }

        public void AddContent(float content)
        {
            Capacity += content;
        }

        public void ShowCapacityToConsole()
        {
            Console.WriteLine(string.Format("W ekspresie jest {0} ml {1}", Capacity, Component.Name));
        }
    }
}