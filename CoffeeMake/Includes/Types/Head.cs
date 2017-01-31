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
        private Dictionary<Component, int> _compInHead;
        public Head()
        {
            _compInHead = new Dictionary<Component, int>();
        }

        public void Add(Component component, int amount)
        {
            if(component == null)
            {
                throw new ArgumentNullException("Skladnik jest nullem.");
            }
            if(amount < 0)
            {
                throw new ArgumentException("Ilosc skladnika jest za mala.");
            }
            _compInHead.Add(component, amount);
        }

        public IEnumerator<KeyValuePair<Component, int>> GetEnumerator()
        {
            return _compInHead.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}