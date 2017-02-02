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
        /// <summary>
        /// Nadaje nazwe
        /// </summary>
        /// /// <exception cref="ArgumentNullException">Gdy nazwa jest pusta lub null</exception>
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
        /// <summary>
        /// Nadaje skladniki przepisu
        /// </summary>
        /// <exception cref="ArgumentNullException">Gdy skladniki sa nullem</exception>
        /// <exception cref="ArgumentException">Gdy skladniki sa pusta lista</exception>
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
        /// <summary>
        /// Tworzy przepis z nazwą i listą skladników wykorzystywanych w przepisie.
        /// </summary>
        /// <param name="name">Nazwa</param>
        /// <param name="components"></param>
        public Recipe(string name, RecipeComponents components)
        {
            Name = name;
            RecipeComponents = components;
        }
    }
}