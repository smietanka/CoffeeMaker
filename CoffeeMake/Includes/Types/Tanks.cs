using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class Tanks
    {
        private List<ITank> AllTanks;
        public Tanks()
        {
            this.AllTanks = new List<ITank>();
        }

        public ITank Get(IComponentType type, string name)
        {
            if (string.IsNullOrEmpty(name) || type == null)
            {
                throw new ArgumentException("Zbiornik jest nullem lub nazwa jest pusta");
            }
            ITank tank = this.AllTanks.Where(x => x.GetType().Equals(type) && x.GetName().Equals(name)).FirstOrDefault();
            if(tank == null)
            {
                throw new NullReferenceException("Nie znaleziono takiego zbiornika");
            }
            return tank;
        }
        public ITank Get(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Nazwa zbiornika jest błędna");
            }
            ITank tank = this.AllTanks.Where(x => x.GetName().Equals(name)).FirstOrDefault();
            if(tank == null)
            {
                throw new NullReferenceException("Nie znaleziono takiego zbiornika");
            }
            return tank;
        }
        public void Add(ITank tank)
        {
            if (tank == null && tank.GetComponentType() == null)
            {
                throw new ArgumentNullException(tank.GetName() + "Zbiornik jest nullem");

            }
            this.AllTanks.Add(tank);
            Console.WriteLine(string.Format("Dodano {0} zbiornik o pojemnosci {1} typu {2}", tank.GetName(), tank.GetCapacity(), tank.GetComponentType().GetName()));
        }
    }
}