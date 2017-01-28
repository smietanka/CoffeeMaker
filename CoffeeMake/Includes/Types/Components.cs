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
        private List<IComponent> AllComponents;
         public Components()
        {
            this.AllComponents = new List<IComponent>();
        }
         public IComponent Get(string name)
         {
             var compon = this.AllComponents.Where(x => x.GetName().Equals(name)).FirstOrDefault();
             if (compon == null)
             {
                 throw new KeyNotFoundException("Nie znaleziono skladnika o nazwie: " + name);
             }
             return compon;
         }
         public void Add(IComponent component)
         {
             if (component == null)
             {
                 throw new ArgumentNullException("skladnik jest pusty");
             }
             this.AllComponents.Add(component);
             Console.WriteLine(string.Format("Dodalo {0} ({1}) do listy skladnikow.", component.GetName(), component.GetComponentType().GetName()));
         }
    }
}
