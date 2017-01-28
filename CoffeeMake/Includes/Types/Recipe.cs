using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class Recipe
    {
        private IList<ComponentDefinition> ComponentsWithAmountAndTemp;
        public Recipe()
        {
            this.ComponentsWithAmountAndTemp = new List<ComponentDefinition>();
        }
        public Recipe(IList<ComponentDefinition> components)
        {
            if (!components.Any())
            {
                throw new ArgumentException("Brak skladnikow");
            }
            this.ComponentsWithAmountAndTemp = components;
        }

        public void AddComponentDefinition(ComponentDefinition def)
        {
            if(def == null)
            {
                throw new ArgumentNullException("Składnik receptury jest nullem.");
            }
            this.ComponentsWithAmountAndTemp.Add(def);
        }
        public IList<ComponentDefinition> GetComponents()
        {
            return this.ComponentsWithAmountAndTemp;
        }
        public void ShowComponentsToConsole()
        {
            foreach (var componentInRecipe in ComponentsWithAmountAndTemp)
            {
                var sb = new StringBuilder();
                sb.Append(string.Format("{0} [{1}, {2}]", componentInRecipe.GetComponent(), string.Format("Temperatura: {0}", componentInRecipe.GetTemperature()), "Ml/Gram: " + componentInRecipe.GetAmount()));
                Console.WriteLine(string.Format("{0}", sb.ToString()));
            }
        }
    }
}