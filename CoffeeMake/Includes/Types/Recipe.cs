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
        private IList<ComponentDefinition> _recipeComponents = new List<ComponentDefinition>();

        public IList<ComponentDefinition> RecipeComponents
        {
            get { return _recipeComponents; }
            set
            {
                if (!value.Any())
                {
                    throw new ArgumentException("Nie podano żadnych składników.");
                }
                _recipeComponents = value;
            }
        }

        public void AddComponentDefinition(ComponentDefinition def)
        {
            if(def == null)
            {
                throw new ArgumentNullException("Składnik receptury jest nullem.");
            }
            this.RecipeComponents.Add(def);
        }

        public void ShowComponentsToConsole()
        {
            foreach (var componentInRecipe in RecipeComponents)
            {
                var sb = new StringBuilder();
                sb.Append(string.Format("{0} [{1}, {2}]", componentInRecipe.ComponentName, string.Format("Temperatura: {0}", componentInRecipe.Temperature), "Ml/Gram: " + componentInRecipe.Amount));
                Console.WriteLine(string.Format("{0}", sb.ToString()));
            }
        }
    }
}