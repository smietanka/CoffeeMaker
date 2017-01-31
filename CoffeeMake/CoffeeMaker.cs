using CoffeeMake.Configuration;
using CoffeeMake.Includes.Types;
using CoffeeMake.Interfaces;
using CoffeeMake.Interfaces.Drink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake
{
    // TODO: Sprobowac cos zrobic z component definition, tj. cos z ta temperatura. bo nie wszystkie skladniki potrzebuja zmienci temperature.
    // Np mąka nie jest potrzebna do podgrzewania
    // czy cos.. wiec nie ma sensu zeby trzymala takie pole.

    // WOJTKOWE SUGESTIE
    // dodac wzorzec dekorator z napojem. Klasa napoj. 
    // sprobowac wzorzec: state, fabryka.
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
            foreach (var component in CurrentConfiguration.Instance.Components)
            {
                _tanks.Add(new Tank(component));
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
                    //pompujemy gotowy skladnik w konkretnej ilosci do glowicy
                    _devices.Pump.Pumping(component, compDefinition.Amount);
                }
            }

            //glowica majac przepompowane skladniki "wypluwa" je tworzac napoj
            IDrink currentDrink = new Drink();
            foreach(var item in _devices.Head)
            {
                currentDrink = new WithComponent(currentDrink, item.Key);
            }
            return currentDrink;

            //ITank sugarTank = Tanks.Where(z => z.Component.Name.Equals("cukier")).FirstOrDefault();
            //if(sugarTank != null)
            //{
            //    _devices.Head.AddToCup(sugarTank, _touchScreen.Sugar);
            //}

            //ITank milkTank = Tanks.Where(z => z.Component.Name.Equals("mleko")).FirstOrDefault();
            //if(milkTank != null)
            //{
            //    _devices.Head.AddToCup(milkTank, _touchScreen.Milk);
            //}
        }
    }
}