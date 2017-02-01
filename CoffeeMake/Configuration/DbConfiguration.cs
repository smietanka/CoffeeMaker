using CoffeeMake.Includes.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Configuration
{
    public class DbConfiguration : IConfiguration
    {
        public Recipes Recipes { get; private set; }
        public Components Components { get; private set; }

        private static readonly object _locker = new object();
        private static DbConfiguration _instance;

        public static DbConfiguration Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        _instance = new DbConfiguration();
                    }
                }
                return _instance;
            }
        }

        private DbConfiguration()
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
            throw new NotImplementedException();
        }
    }
}
