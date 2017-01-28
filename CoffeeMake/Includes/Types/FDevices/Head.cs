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
        private string Name;

        public Head(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Nazwa jest pusta lub nullem");
            }
            this.Name = name;
        }
        public void AddToCup(ITank component, int capacity)
        {
            if(component == null)
            {
                throw new ArgumentNullException("Składnik/zbiornik jest nullem");
            }

            if(component.GetComponentType().GetName().Equals(Constans.LIQUID_TYPE))
            {
                Console.WriteLine(string.Format("Dodaje {0} mililitrow {1} ({3}) o temperaturze {2} do kubka.", capacity, component.GetName(), component.GetComponent().GetTemperature(), component.GetComponentType().GetName()));
            }
            else
            {
                Console.WriteLine(string.Format("Dodaje {0} gramow {1} ({2}) do kubka.", capacity, component.GetName(), component.GetComponentType().GetName()));
            }
            component.RemoveContent(capacity);
        }

        public void RunJob()
        {
            throw new NotImplementedException();
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Nazwa jest pusta lub nullem");
            }
            this.Name = name;
        }

        public string GetName()
        {
            return this.Name;
        }
    }
}
