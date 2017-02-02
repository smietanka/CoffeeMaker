using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class Head : IHead
    {
        private List<Component> _compInHead;
        /// <summary>
        /// Tworzy obiekt oraz inicjalizuje pusta liste skladnikow w glowicy
        /// </summary>
        public Head()
        {
            _compInHead = new List<Component>();
        }
        /// <summary>
        /// Dodaje konkretny skladnik do glowicy
        /// </summary>
        /// <param name="component">Skladnik.</param>
        /// <exception cref="ArgumentNullException">W momencie gdy skladnik jest null.</exception>
        public void Add(Component component)
        {
            if(component == null)
            {
                throw new ArgumentNullException("Skladnik jest nullem.");
            }
            _compInHead.Add(component);
        }

        public IEnumerator<Component> GetEnumerator()
        {
            return _compInHead.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}