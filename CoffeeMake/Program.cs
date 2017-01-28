using CoffeeMake.Includes.Types;
using CoffeeMake.Includes.Types.ComponentType;
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

            Touch touchScreen = coffeeMaker.GetTouch();

            coffeeMaker.AddTank(Constans.COFFEE, new Dry(), 1000, true);

            coffeeMaker.AddTank(Constans.SUGAR, new Dry(), 1000, false);

            coffeeMaker.AddTank(Constans.WATER, new Liquid(), 5000, false);

            coffeeMaker.AddTank(Constans.MILK, new Liquid(), 4000, false);

            coffeeMaker.AddDevice(new Heater(Constans.HEATER_NAME));
            coffeeMaker.AddDevice(new Head(Constans.HEAD_NAME));
            coffeeMaker.AddDevice(new Grinder(Constans.GRINDER_NAME));

            var firstOption = new Option("Kawa czarna");
            Recipe firstOptionRecipe = new Recipe();
            firstOptionRecipe.AddComponentDefinition(new ComponentDefinition(Constans.COFFEE, 30));
            firstOptionRecipe.AddComponentDefinition(new ComponentDefinition(Constans.WATER, 100, 200));
            firstOption.SetRecipe(firstOptionRecipe);
            touchScreen.AddOption(firstOption);

            var secondOption = new Option("sama woda goraca");
            Recipe secondOptionRecipe = new Recipe();
            secondOptionRecipe.AddComponentDefinition(new ComponentDefinition(Constans.WATER, 100, 200));
            secondOption.SetRecipe(secondOptionRecipe);
            touchScreen.AddOption(secondOption);

            coffeeMaker.ShowOptions();

            Option choosenOption = touchScreen.GetCurrentOption();

            coffeeMaker.Do(choosenOption);

            Console.ReadKey();
        }
    }
}