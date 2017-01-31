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
                if (!value.Any())
                {
                    throw new ArgumentException("Nie podano żadnych składników.");
                }
                _recipeComponents = value;
            }
        }
        public Recipe(string name, RecipeComponents components)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("nazwa pusta lub null");
            }
            if(components == null)
            {
                throw new ArgumentNullException("Skladniki przepisu jest null");
            }
            if(!components.Any())
            {
                throw new KeyNotFoundException("Psuta lista skladnikow");
            }
        }
    }
}