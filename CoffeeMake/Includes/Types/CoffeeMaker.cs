using CoffeeMake.Includes.Types.FDevices;
using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    // TODO: cos z listami ogarnac? to trzeba kurde.
    // Przelozyc WriteLiny na GUIca
    // TODO: Sprobowac cos zrobic z component definition, tj. cos z ta temperatura. bo nie wszystkie skladniki potrzebuja zmienci temperature. Np mąka nie jest potrzebna do podgrzewania
    // czy cos.. wiec nie ma sensu zeby trzymala takie pole.
    //TODO do zmiany jeszcze touch
    public class CoffeeMaker : IExpress
    {
        private Devices _devices = new Devices();
        public Devices Devices
        {
            get { return _devices; }
        }

        private Touch _touchScreen = new Touch();
        public Touch Touch
        {
            get { return _touchScreen; }
        }
        private IList<ITank> Tanks = new List<ITank>();

        public void Do(Option option)
        {
            option.Recipe.ShowComponentsToConsole();

            foreach (ComponentDefinition compDefinition in option.Recipe.RecipeComponents)
            {
                ITank tankWithComponent = Tanks.Where(z => z.Component.Name.Equals(compDefinition.ComponentName)).FirstOrDefault();
                if(tankWithComponent != null)
                {
                    if (tankWithComponent.Component.Grindable)
                    {
                        Devices.Gridner.Grind(tankWithComponent.Component);
                    }

                    if (tankWithComponent.Component.Type.Equals(ComponentType.LIQUID))
                    {
                        _devices.Heater.Heat(tankWithComponent.Component, compDefinition.Temperature);
                    }
                    Devices.Head.AddToCup(tankWithComponent, compDefinition.Amount);
                }
            }
            ITank sugarTank = Tanks.Where(z => z.Component.Name.Equals("cukier")).FirstOrDefault();
            if(sugarTank != null)
            {
                Devices.Head.AddToCup(sugarTank, _touchScreen.Sugar);
            }

            ITank milkTank = Tanks.Where(z => z.Component.Name.Equals("mleko")).FirstOrDefault();
            if(milkTank != null)
            {
                Devices.Head.AddToCup(milkTank, _touchScreen.Milk);
            }
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

            Tanks.Add(new Tank(capacity, new Component(name, type, grindable)));
        }
    }
}