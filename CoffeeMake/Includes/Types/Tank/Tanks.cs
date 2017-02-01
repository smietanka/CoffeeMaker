using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types.Tank
{
    public class Tanks : IEnumerable<ITank>
    {
        private List<ITank> _tanks;

        public Tanks()
        {
            _tanks = new List<ITank>();
        }

        public Tanks(List<ITank> paramTanks)
        {
            if (paramTanks == null)
                throw new ArgumentNullException("Lista zbiornikow jest nullem");
            _tanks = paramTanks;
        }

        public void Add(ITank tank)
        {
            if(tank == null)
            {
                throw new ArgumentNullException("Zbiornik jest nullem");
            }
            _tanks.Add(tank);
        }

        public IEnumerator<ITank> GetEnumerator()
        {
            return _tanks.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
