using CoffeeMake.Includes.Types;
using CoffeeMake.Includes.Types.FDevices;
using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake
{
    class Program
    {
        /// <summary>
        /// Tworzy instancje ekspresu do kawy.
        /// Dodajemy:
        /// - pojemniki ze składnikami
        /// - urządzenia ekspresu, np. głowica, grzałka itp.
        /// - opcje wyboru
        /// Wyświetlamy:
        /// - panel dotykowy (możliwe opcje do wyboru)
        /// Na koniec tworzymy napój z wybranej opcji.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            IExpress coffeeMaker = new CoffeeMaker();

            coffeeMaker.AddTank("kawa", ComponentType.DRY, 1000, true);

            coffeeMaker.AddTank("cukier", ComponentType.DRY, 1000, false);

            coffeeMaker.AddTank("woda", ComponentType.LIQUID, 5000, false);

            coffeeMaker.AddTank("mleko", ComponentType.LIQUID, 4000, false);

            coffeeMaker.Devices.Head = new Head();
            coffeeMaker.Devices.Heater = new Heater();
            coffeeMaker.Devices.Gridner = new Grinder();

            var firstOption = new Option("Kawa czarna");
            Recipe firstOptionRecipe = new Recipe();
            firstOptionRecipe.AddComponentDefinition(new ComponentDefinition("kawa", 30));
            firstOptionRecipe.AddComponentDefinition(new ComponentDefinition("woda", 100, 200));
            firstOption.Recipe = firstOptionRecipe;
            coffeeMaker.Touch.AddOption(firstOption);

            var secondOption = new Option("sama woda goraca");
            Recipe secondOptionRecipe = new Recipe();
            secondOptionRecipe.AddComponentDefinition(new ComponentDefinition("woda", 100, 200));
            secondOption.Recipe = secondOptionRecipe;
            coffeeMaker.Touch.AddOption(secondOption);

            coffeeMaker.Touch.ShowOptions();

            Option choosenOption = coffeeMaker.Touch.CurrentOption;

            coffeeMaker.Do(choosenOption);

            Console.ReadKey();
        }
    }
}