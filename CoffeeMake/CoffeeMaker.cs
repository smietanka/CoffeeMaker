using CoffeeMake.Configuration;
using CoffeeMake.Includes.Types;
using CoffeeMake.Includes.Types.Tank;
using CoffeeMake.Interfaces;
using System;
using System.Linq;

namespace CoffeeMake
{
    public class CoffeeMaker
    {
        private Devices _devices;
        private Tanks _tanks;
        public CoffeeMaker()
        {
            _devices = new Devices();
            InitializeTanks();
        }

        public CoffeeMaker(Devices paramDevices)
        {
            if(paramDevices == null)
            {
                throw new ArgumentNullException();
            }
            _devices = paramDevices;
            InitializeTanks();
        }

        private void InitializeTanks()
        {
            _tanks = new Tanks();
            foreach (var component in SingletonConfiguration.Instance.Components)
            {
                _tanks.Add(TankFactory.CreateTank(component));
            }
        }

        public IDrink Do(Recipe recipe)
        {
            if(recipe == null)
            {
                throw new ArgumentNullException("Przepis jest nullem.");
            }

            foreach (ComponentDefinition compDefinition in recipe.RecipeComponents)
            {
                if(compDefinition.Component != null)
                {
                    if (compDefinition.Component.Grindable)
                    {
                        _devices.Grinder.Grind(compDefinition.Component);
                    }

                    if (compDefinition.Component.Type.Equals(ComponentType.LIQUID))
                    {
                        _devices.Heater.Heat(compDefinition.Component, compDefinition.Temperature);
                    }
                    _devices.Pump.Pumping(compDefinition.Component);
                }
            }

            IDrink currentDrink = new Drink();
            foreach(var item in _devices.Head)
            {
                currentDrink = new WithComponent(currentDrink, item);
            }
            return currentDrink;
        }
    }
}