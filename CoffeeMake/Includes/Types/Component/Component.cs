using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class Component
    {
        private string _name;
        /// <summary>
        /// Zwraca lub nadaje nazwe
        /// </summary>
        /// <exception cref="ArgumentNullException">W momencie gdy nazwa jest pusta lub null.</exception>"
        public string Name
        {
            get { return _name; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Nazwa jest pusta lub nullem.");
                }
                _name = value;
            }
        }
        /// <summary>
        /// Zwraca lub nadaje typ skladnika
        /// </summary>
        public ComponentType Type { get; private set; }

        /// <summary>
        /// Zwraca lub nadaje czy skladnik jest mielony
        /// </summary>
        public bool Grindable { get; private set; }

        private float _temperature;
        /// <summary>
        /// Temperatura skladnika
        /// </summary>
        /// <exception cref="ArgumentException">W momencie nadawania  gdy temperatura jest za niska.</exception>
        public float Temperature
        {
            get { return _temperature; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Temperatura jest za niska");
                }
                _temperature = value;
            }
        }
        /// <summary>
        /// Tworzy obiekt skladnika z domyslna zerowa temperatura.
        /// </summary>
        /// <param name="name">Nazwa składnika</param>
        /// <param name="type">Typ składnika</param>
        /// <param name="grindable">Czy jest składnik mielony.</param>
        public Component(string name, ComponentType type, bool grindable)
        {
            Name = name;
            Type = type;
            Grindable = grindable;
            Temperature = 0;
        }
    }
}
