using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class Grinder : IGrinder
    {
        public void Grind(Component component)
        {
            if(component == null)
            {
                throw new ArgumentNullException("Skladnik jest nullem.");
            }

            if (!component.Grindable)
            {
                throw new ArgumentException("Nie mozna zmielic skladnika ktory nie jest do mielenia");
            }

            if (!component.Type.Equals(ComponentType.DRY))
            {
                throw new ArgumentException("Probujemy zmielic zly rodzaj skladnika");
            }
        }
    }
}
