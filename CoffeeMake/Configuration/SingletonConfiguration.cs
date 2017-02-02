using CoffeeMake.Includes.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Configuration
{
    public class SingletonConfiguration : IConfiguration
    {
        public Recipes Recipes { get; private set; }
        public Components Components { get; private set; }

        private static readonly object _locker = new object();
        private static SingletonConfiguration _instance;
        /// <summary>
        /// Zwraca instancje konfiguracji pobieranej z bazy danych.
        /// </summary>
        public static SingletonConfiguration Instance
        {
            get
            {
                lock (_locker)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonConfiguration();
                    }
                }
                return _instance;
            }
        }
        /// <summary>
        /// Tworzy podstawowe kolekcje oraz ładuje pierwszy raz listę składników.
        /// </summary>
        private SingletonConfiguration()
        {
            this.Recipes = new Recipes();
            this.Components = new Components();
            Load();
        }

        /// <summary>
        /// Inicjalizuje listę składników i przepisów z czegos tam
        /// </summary>
        private void Load()
        {
            //TODO: pobieranie listy przepisow z czegos tam

            //TODO: pobieranie listy skladnikow z czegos tam
        }
    }
}
