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
        string GetName();
        void SetName(string name);
        void ShowOptions();
        Touch GetTouch();
        void AddTank(string name, IComponentType type, int capacity, bool grindable);
        ITank GetTank(string name);
        void AddDevice(IDevice device);
    }
}
