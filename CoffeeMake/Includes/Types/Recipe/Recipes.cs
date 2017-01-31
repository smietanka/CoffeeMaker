using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class Recipes : IEnumerable<Recipe>
    {
        private List<Recipe> _recipes;
        public Recipes()
        {
            _recipes = new List<Recipe>();
        }
        public Recipes(List<Recipe> paramRecipes)
        {
            if(paramRecipes == null) 
                throw new ArgumentNullException("Lista receptuj jest nullem.");
            _recipes = paramRecipes;
        }
        public IEnumerator<Recipe> GetEnumerator()
        {
            return _recipes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
