using CoffeeMake.Includes.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Interfaces
{
    public interface IHead : IEnumerable<Component>
    {
        void Add(Component component);
    }
}
