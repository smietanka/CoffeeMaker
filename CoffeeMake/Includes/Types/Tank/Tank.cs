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
        public Component Component { get; private set; }

        public float Capacity { get; set; }

        /// <summary>
        /// Tworzy domyslny zbiornik
        /// </summary>
        /// <param name="component">Skladnik</param>
        public Tank(Component component)
        {
            Component = component;
        }

        /// <summary>
        /// Pobiera ze zbiornika ilosc dostepnego skladnika 
        /// </summary>
        /// <param name="content">Ilosc do pobrania</param>
        /// <exception cref="ArgumentException">W momencie gdy chcemy pobrac za duzo zawartosci lub content jest mniejsze od 0</exception>
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
