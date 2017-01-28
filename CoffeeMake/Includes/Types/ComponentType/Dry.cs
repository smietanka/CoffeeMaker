using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types.ComponentType
{
    public class Dry : IComponentType
    {
        public string GetName()
        {
            return Constans.DRY_TYPE;
        }
    }
}
