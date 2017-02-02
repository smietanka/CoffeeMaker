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
        /// <summary>
        /// Tworzy obiekt oraz inicjalizuje pusta liste przepisow.
        /// </summary>
        public Recipes()
        {
            _recipes = new List<Recipe>();
        }
        /// <summary>
        /// Tworzy obiekt z lista przepisow
        /// </summary>
        /// <param name="paramRecipes">Lista przepisow</param>
        /// <exception cref="ArgumentNullException">Gdy lista przepisow jest null</exception>
        public Recipes(List<Recipe> paramRecipes)
        {
            if(paramRecipes == null) 
                throw new ArgumentNullException("Lista receptury jest nullem.");
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
