using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class RecipeComponents : IEnumerable<ComponentDefinition>
    {
        List<ComponentDefinition> _compDefinitions;

        public RecipeComponents()
        {
            _compDefinitions = new List<ComponentDefinition>();
        }

        public RecipeComponents(List<ComponentDefinition> paramDef)
        {
            if (paramDef == null)
                throw new ArgumentNullException("Lista potrzebnych skladnikow do przepisu jest nullem");
            _compDefinitions = paramDef;
        }

        public IEnumerator<ComponentDefinition> GetEnumerator()
        {
            return _compDefinitions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
