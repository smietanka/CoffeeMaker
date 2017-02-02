using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types.Tank
{
    public class DryTank : Tank
    {
        /// <summary>
        /// Tworzy obiekt zbiornika na skladniki suche.
        /// </summary>
        /// <param name="component">Skladnik</param>
        /// <exception cref="ArgumentNullException">W momencie gdy skladnik jest null</exception>
        /// <exception cref="ArgumentException">W momencie gdy skladnik jest zlym typem</exception>
        public DryTank(Component component)
            : base(component)
        {
            if(component == null)
            {
                throw new ArgumentNullException("Skladnik jest null");
            }

            if(!component.Type.Equals(ComponentType.DRY))
            {
                 throw new ArgumentException("Skladnik jest zlym typem.");
            }
        }
    }
}