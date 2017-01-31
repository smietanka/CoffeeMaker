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

        public DbConfiguration()
        {
            this.Recipes = new Recipes();
            this.Components = new Components();
        }

        /// <summary>
        /// Inicjalizuje listę składników i przepisów z bazy danych.
        /// </summary>
        public void Load()
        {
            //TODO: pobieranie z bazy danych listy przepisow

            //TODO: pobieranie z bazy danych listy skladnikow
        }
    }
}
