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

        /// <summary>
        /// Tworzy obiekt oraz inicjalizuje pusta liste zbiornikow.
        /// </summary>
        public Tanks()
        {
            _tanks = new List<ITank>();
        }
        /// <summary>
        /// Tworzy obiekt z lista zbiornikow
        /// </summary>
        /// <param name="paramTanks">Lista zbiornikow</param>
        public Tanks(List<ITank> paramTanks)
        {
            if (paramTanks == null)
                throw new ArgumentNullException("Lista zbiornikow jest nullem");
            _tanks = paramTanks;
        }

        /// <summary>
        /// Dodaje do aktualnej listy zbiornik
        /// </summary>
        /// <param name="tank">Zbiornik</param>
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
