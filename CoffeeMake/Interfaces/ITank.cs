using CoffeeMake.Includes.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Interfaces
{
    public interface ITank
    {
        Component Component { get; set; }
        float Capacity { get; set; }

        void RemoveContent(float content);
    }
}
