using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types.Tank
{
    public abstract class Tank : ITank
    {
        private Component _component;
        public virtual Component Component
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

        public float Capacity { get; set; }

        public Tank(Component component)
        {
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
    }
}
