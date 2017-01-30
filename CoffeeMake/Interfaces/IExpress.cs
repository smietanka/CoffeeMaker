using CoffeeMake.Includes.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Interfaces
{
    public interface IExpress
    {
        Touch Touch { get; }
        Devices Devices { get; }

        void Do(Option option);
        

        void AddTank(string name, ComponentType type, int capacity, bool grindable);
    }
}
