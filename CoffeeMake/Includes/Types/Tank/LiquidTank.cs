using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class LiquidTank : ITank
    {
        public float Capacity { get; private set; }

        private Component _component;
        public Component Component
        {
            get { return _component; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Składnik jest nullem.");
                }
                if (!value.Type.Equals(ComponentType.LIQUID))
                {
                    throw new ArgumentException("Skladnik nie jest przeznaczony do tego zbiornika");
                }
                _component = value;
            }
        }

        public LiquidTank(Component component)
        {
            Component = component;
            Capacity = 1000;
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
    }
}