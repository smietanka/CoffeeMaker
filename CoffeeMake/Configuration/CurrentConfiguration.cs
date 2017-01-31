using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Configuration
{
    public class CurrentConfiguration
    {
        private static IConfiguration instance;

        private CurrentConfiguration() { }

        //TODO: Możliwość wyboru innych czytania konfiguracji z innych miejsc - np. z pliku
        public static IConfiguration Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DbConfiguration();
                }
                return instance;
            }
        }
    }
}