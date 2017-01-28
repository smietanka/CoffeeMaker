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
        private string Name;
        public Grinder()
        {
            this.Name = "Brak";
        }
        public Grinder(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Nazwa jest pusta lub nullem");
            }
            this.Name = name;
        }

        public bool Grind(IComponent component)
        {
            if (!component.GetGrindable())
            {
                throw new ArgumentException("Nie mozna zmielic skladnika ktory nie jest do mielenia");
            }

            if (!component.GetComponentType().GetName().Equals(Constans.DRY_TYPE))
            {
                throw new ArgumentException("Probujemy zmielic zly rodzaj skladnika");
            }
            Console.WriteLine(string.Format("Zmielilo {0}", component.GetName()));
            return true;
        }

        public void RunJob()
        {
            throw new NotImplementedException();
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Nazwa jest pusta lub nullem");
            }
            this.Name = name;
        }

        public string GetName()
        {
            return this.Name;
        }
    }
}
