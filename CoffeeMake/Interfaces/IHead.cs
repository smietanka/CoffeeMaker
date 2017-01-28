using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Interfaces
{
    public interface IHead : IDevice
    {
        void AddToCup(ITank component, int capacity);
    }
}
