using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Interfaces
{
    public interface IComponent
    {
        public string Name { get; set; }

        void SetComponentType(IComponentType type);
        IComponentType GetComponentType();

        void SetGrindable(bool grindable);
        bool GetGrindable();

        void SetTemperature(float temperature);
        float GetTemperature();
    }
}
