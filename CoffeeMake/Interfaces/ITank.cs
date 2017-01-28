using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Interfaces
{
    public interface ITank : IDevice
    {
        float GetCapacity();
        void SetCapacity(float capacity);

        IComponentType GetComponentType();
        void SetComponentType(IComponentType type);

        IComponent GetComponent();
        void SetComponent(IComponent component);

        void RemoveContent(float content);
        void AddContent(float content);

        void ShowCapacityToConsole();
    }
}
