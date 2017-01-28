using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class Option
    {
        private string Name;
        private Recipe Recipe;

        public Option()
        {
            this.Name = "brak";
            this.Recipe = new Recipe();
        }
        public Option(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Nazwa jest nullem lub pusta");
            }
            this.Name = name;
        }
        public string GetName()
        {
            return this.Name;
        }

        public Recipe GetRecipe()
        {
            return this.Recipe;
        }
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Pusta nazwa");
            }
            this.Name = name;
        }
        public void SetRecipe(Recipe recipe)
        {
            if (recipe.Equals(null))
            {
                throw new ArgumentNullException("Pusta receptura");
            }
            this.Recipe = recipe;
        }
    }
}