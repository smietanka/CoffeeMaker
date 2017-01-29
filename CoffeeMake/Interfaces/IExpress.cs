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
        void Do(Option option);
        Touch Touch { get; }

        void ShowOptions();
        void AddTank(string name, ComponentType type, int capacity, bool grindable);
        ITank GetTank(string name);
        void AddDevice(IDevice device);
    }
}
