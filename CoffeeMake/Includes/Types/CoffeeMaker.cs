using CoffeeMake.Includes.Types.ComponentType;
using CoffeeMake.Includes.Types.FDevices;
using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class CoffeeMaker : IExpress
    {
        private string Name = "Ekspres";
        private Devices Devices;
        private Components Components;
        private Tanks Tanks;
        private Touch TouchScreen;

        public CoffeeMaker()
        {
            this.Devices = new Devices();
            this.Components = new Components();
            this.Tanks = new Tanks();
            this.TouchScreen = new Touch(Constans.TOUCH_NAME);
        }

        public void Do(Option option)
        {
            IHead head = this.Devices.GetHead();

            Recipe drinkRecipe = option.GetRecipe();
            IList<ComponentDefinition> drinkComponents = drinkRecipe.GetComponents();

            drinkRecipe.ShowComponentsToConsole();

            foreach (ComponentDefinition componentDefinition in drinkComponents)
            {
                string componentName = componentDefinition.GetComponent();
                ITank tankWithComponent = Tanks.Get(componentName);
                string componentTypeName = tankWithComponent.GetComponentType().GetName();
                
                if(tankWithComponent.GetComponent().GetGrindable())
                {
                    IGrinder grinder = this.Devices.GetGrinder();
                    grinder.Grind(tankWithComponent.GetComponent());
                }

                if(tankWithComponent.GetComponentType().GetType().IsEquivalentTo(new Liquid().GetType()))
                {
                    IHeater heater = this.Devices.GetHeater();
                    var componentTemperature = componentDefinition.GetTemperature();

                    heater.Heat(tankWithComponent.GetComponent(), componentDefinition.GetTemperature());
                }
                head.AddToCup(tankWithComponent, componentDefinition.GetAmount());
            }

            head.AddToCup(Tanks.Get(Constans.SUGAR), TouchScreen.GetSugar());
            head.AddToCup(Tanks.Get(Constans.MILK), TouchScreen.GetMilk());
        }

        public string GetName()
        {
            return this.Name;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Nazwa jest pusta lub nullem");
            }
            this.Name = name;
        }

        public void ShowOptions()
        {
            TouchScreen.ShowOptions();
        }

        public Touch GetTouch()
        {
            return TouchScreen;
        }

        public void AddDevice(IDevice device)
        {
            this.Devices.Add(device);
        }

        public void AddTank(string name, IComponentType type, int capacity, bool grindable)
        {
            if(type == null || string.IsNullOrEmpty(name) || capacity < 0)
            {
                throw new ArgumentException("Któryś z parametrów jest błędny.");
            }

            Component component = new Component(name, type, grindable);
            Components.Add(component);
            Tank tank = new Tank(name, capacity, type, component);
            Tanks.Add(tank);
        }

        public ITank GetTank(string name)
        {
            return Tanks.Get(name);
        }
    }
}