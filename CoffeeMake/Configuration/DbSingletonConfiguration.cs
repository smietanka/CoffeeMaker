using CoffeeMake.Includes.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Configuration
{
    public class DbSingletonConfiguration : IConfiguration
    {
        public Recipes Recipes { get; private set; }
        public Components Components { get; private set; }

        private static readonly object _locker = new object();
        private static DbSingletonConfiguration _instance;
        /// <summary>
        /// Zwraca instancje konfiguracji pobieranej z bazy danych.
        /// </summary>
        public static DbSingletonConfiguration Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        _instance = new DbSingletonConfiguration();
                    }
                }
                return _instance;
            }
        }
        /// <summary>
        /// Tworzy podstawowe kolekcje oraz ładuje pierwszy raz listę składników.
        /// </summary>
        private DbSingletonConfiguration()
        {
            this.Recipes = new Recipes();
            this.Components = new Components();
            Load();
        }

        /// <summary>
        /// Inicjalizuje listę składników i przepisów z bazy danych.
        /// </summary>
        private void Load()
        {
            //TODO: pobieranie z bazy danych listy przepisow

            //TODO: pobieranie z bazy danych listy skladnikow
        }
    }
}
