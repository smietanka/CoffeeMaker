using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class Components
    {
        private IList<Component> AllComponents = new List<Component>();

         public Component Get(string name)
         {
             var compon = this.AllComponents.Where(x => x.Name.Equals(name)).FirstOrDefault();
             if (compon == null)
             {
                 throw new KeyNotFoundException("Nie znaleziono skladnika o nazwie: " + name);
             }
             return compon;
         }
         public void Add(Component component)
         {
             if (component == null)
             {
                 throw new ArgumentNullException("skladnik jest pusty");
             }
             this.AllComponents.Add(component);
             Console.WriteLine(string.Format("Dodalo {0} ({1}) do listy skladnikow.", component.Name, component.Type.ToString()));
         }
    }
}
