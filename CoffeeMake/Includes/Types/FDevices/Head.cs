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
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Nazwa jest pusta lub nullem");
                }
                _name = value;
            }
        }

        public Head(string name)
        {
            Name = name;
        }

        public void AddToCup(ITank tank, int capacity)
        {
            if(tank == null)
            {
                throw new ArgumentNullException("Zbiornik jest nullem");
            }

            if(capacity > 0)
            {
                if (tank.Type.Equals(ComponentType.LIQUID))
                {
                    Console.WriteLine(string.Format("Dodaje {0} mililitrow {1} ({3}) o temperaturze {2} do kubka.", capacity, tank.Name, tank.Component.Temperature, tank.Type.ToString()));
                }
                else
                {
                    Console.WriteLine(string.Format("Dodaje {0} gramow {1} ({2}) do kubka.", capacity, tank.Name, tank.Type.ToString()));
                }
                tank.RemoveContent(capacity);
            }
        }
    }
}
