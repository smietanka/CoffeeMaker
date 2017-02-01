using CoffeeMake.Configuration;
using CoffeeMake.Includes.Types;
using CoffeeMake.Includes.Types.Tank;
using CoffeeMake.Interfaces;
using System;
using System.Linq;

namespace CoffeeMake
{
    //TODO: Rozdzielic ComponentDefinition na dwie osobne klasy. z temperatura i bez.
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
            foreach (var component in DbSingletonConfiguration.Instance.Components)
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
                Component component = _tanks.Where(z => z.Component.Name.Equals(compDefinition.ComponentName)).FirstOrDefault().Component;

                if(component != null)
                {
                    if (component.Grindable)
                    {
                        _devices.Grinder.Grind(component);
                    }

                    if (component.Type.Equals(ComponentType.LIQUID))
                    {
                        _devices.Heater.Heat(component, compDefinition.Temperature);
                    }
                    _devices.Pump.Pumping(component);
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