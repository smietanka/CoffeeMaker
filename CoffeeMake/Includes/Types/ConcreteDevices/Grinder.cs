using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types.FDevices
{
    public class Grinder : IGrinder
    {
        public bool Grind(Component component)
        {
            if (!component.Grindable)
            {
                throw new ArgumentException("Nie mozna zmielic skladnika ktory nie jest do mielenia");
            }

            if (!component.Type.Equals(ComponentType.DRY))
            {
                throw new ArgumentException("Probujemy zmielic zly rodzaj skladnika");
            }
            Console.WriteLine(string.Format("Zmielilo {0}", component.Name));
            return true;
        }
    }
}
