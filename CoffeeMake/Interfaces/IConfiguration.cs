using CoffeeMake.Includes.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Configuration
{
    public interface IConfiguration
    {
        Recipes Recipes { get; }
        Components Components { get; }
    }
}
