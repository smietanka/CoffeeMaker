using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class Option
    {
        private string _name;
        public string Name {
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

        private Recipe _recipe;
        public Recipe Recipe {
            get { return _recipe; }
            set
            {
                if (value.Equals(null))
                {
                    throw new ArgumentNullException("Pusta receptura");
                }
                _recipe = value;
            }
        }

        public Option(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Nazwa jest nullem lub pusta");
            }
            this._name = name;
        }
    }
}