using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types.FDevices
{
    public class Head : IHead
    {
        public void AddToCup(ITank tank, int capacity)
        {
            if(tank == null)
            {
                throw new ArgumentNullException("Zbiornik jest nullem");
            }

            if(capacity > 0)
            {
                if (tank.Component.Type.Equals(ComponentType.LIQUID))
                {
                    Console.WriteLine(string.Format("Dodaje {0} mililitrow {1} ({3}) o temperaturze {2} do kubka.", capacity, tank.Component.Name, tank.Component.Temperature, tank.Component.Type.ToString()));
                }
                else
                {
                    Console.WriteLine(string.Format("Dodaje {0} gramow {1} ({2}) do kubka.", capacity, tank.Component.Name, tank.Component.Type.ToString()));
                }
                tank.RemoveContent(capacity);
            }
        }
    }
}
