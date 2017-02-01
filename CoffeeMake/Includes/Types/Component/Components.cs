using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class Components : IEnumerable<Component>
    {
        private List<Component> _components;
        /// <summary>
        /// Inicjalizuje pusta liste skladniko.
        /// </summary>
        public Components()
        {
            _components = new List<Component>();
        }
        /// <summary>
        /// Tworzy obiekt z wgrana juz lista skladnikow.
        /// </summary>
        /// <param name="paramComp">Lista skladnikow</param>
        public Components(List<Component> paramComp)
        {
            if (paramComp == null)
                throw new ArgumentNullException("Lista skladnikow jest nullem.");
            _components = paramComp;
        }
        /// <summary>
        /// Dodaje do listy skladnikow konkretny skladnik
        /// </summary>
        /// <param name="comp"></param>
        public void Add(Component comp)
        {
            if(comp == null)
            {
                throw new ArgumentNullException("skladnik ejst null");
            }
            _components.Add(comp);
        }

        public IEnumerator<Component> GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
