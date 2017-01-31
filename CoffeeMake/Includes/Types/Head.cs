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
        public Head()
        {
            _compInHead = new List<Component>();
        }

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