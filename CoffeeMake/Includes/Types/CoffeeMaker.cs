using CoffeeMake.Includes.Types.FDevices;
using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    // TODO: Usunac if gdzie sprawdzamy wszystkei zmiennee. (if cos I cos I cos then) ktorys z parametrow zal
    // TODO: cos z listami ogarnac? to trzeba kurde.
    // Przelozyc WriteLiny na GUIca
    // TODO: Sprobowac cos zrobic z component definition, tj. cos z ta temperatura. bo nie wszystkie skladniki potrzebuja zmienci temperature. Np mąka nie jest potrzebna do podgrzewania
    // czy cos.. wiec nie ma sensu zeby trzymala takie pole.
    //TODO do zmiany jeszcze touch
    public class CoffeeMaker : IExpress
    {
        private Devices Devices;
        private Components Components;
        private Tanks Tanks;

        private Touch _touchScreen;
        public Touch Touch
        {
            get { return _touchScreen; }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("Panel dotykowy jest nullsem");
                }
                _touchScreen = value;
            }
        }

        public CoffeeMaker()
        {
            Devices = new Devices();
            Components = new Components();
            Tanks = new Tanks();
            Touch = new Touch(Constans.TOUCH_NAME);
        }

        public void Do(Option option)
        {
            IHead head = Devices.GetHead();

            option.Recipe.ShowComponentsToConsole();

            foreach (ComponentDefinition compDefinition in option.Recipe.RecipeComponents)
            {
                ITank tankWithComponent = Tanks.Get(compDefinition.ComponentName);
                
                if(tankWithComponent.Component.Grindable)
                {
                    IGrinder grinder = Devices.GetGrinder();
                    grinder.Grind(tankWithComponent.Component);
                }

                if(tankWithComponent.Type.Equals(ComponentType.LIQUID))
                {
                    IHeater heater = Devices.GetHeater();
                    var componentTemperature = compDefinition.Temperature;

                    heater.Heat(tankWithComponent.Component, compDefinition.Temperature);
                }
                head.AddToCup(tankWithComponent, compDefinition.Amount);
            }

            head.AddToCup(Tanks.Get(Constans.SUGAR), _touchScreen.GetSugar());
            head.AddToCup(Tanks.Get(Constans.MILK), _touchScreen.GetMilk());
        }

        public void ShowOptions()
        {
            _touchScreen.ShowOptions();
        }

        public void AddDevice(IDevice device)
        {
            Devices.Add(device);
        }

        public void AddTank(string name, ComponentType type, int capacity, bool grindable)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Nazwa jest nullem.");
            }
            if(capacity < 0)
            {
                throw new ArgumentException("Zła wartość pojemności.");
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