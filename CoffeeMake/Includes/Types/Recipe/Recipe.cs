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
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Pusta nazwa");
                }
                _name = value;
            }
        }

        private RecipeComponents _recipeComponents;
        public RecipeComponents RecipeComponents
        {
            get { return _recipeComponents; }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("Skladniki sa nullem");
                }
                if (!value.Any())
                {
                    throw new ArgumentException("Nie podano żadnych składników.");
                }
                _recipeComponents = value;
            }
        }
        public Recipe(string name, RecipeComponents components)
        {
            Name = name;
            RecipeComponents = components;
        }
    }
}