using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class Touch : ITouch
    {
        private static int IndexedOption = 0;
        private IDictionary<int, Option> Options = new Dictionary<int, Option>();

        private int _sugar;
        public int Sugar
        {
            get
            {
                return _sugar;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Ilosc cukru jest w złym przedziale. Podaj wartość od 0 do 100.");
                }
                _sugar = value;
            }
        }
        private int _milk;
        public int Milk
        {
            get
            {
                return _milk;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Ilosc mleka jest w złym przedziale. Podaj wartość od 0 do 100.");
                }
                _milk = value;
            }
        }

        private Option _currentOption;
        public Option CurrentOption
        {
            get
            {
                if (_currentOption == null)
                {
                    throw new NullReferenceException("Nie wybrano żadnej opcji, dlatego aktualna opcja jest pusta.");
                }
                return _currentOption;
            }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("Opcja jest nullem.");
                }
                _currentOption = value;
            }
        }

        public void AddOption(Option option)
        {
            if (option == null)
            {
                throw new ArgumentNullException("opcja jest nullem");
            }
            Options.Add(IndexedOption, option);
            IndexedOption++;
        }

        public void ShowOptions()
        {
            if (!this.Options.Any()) throw new IndexOutOfRangeException("Brak opcji do wyswietlenia");
            else
            {
                foreach(var option in Options)
                {
                    Console.WriteLine(string.Format("{0}. {1}", option.Key, option.Value.Name));
                }

                int optionIn = Convert.ToInt32(Console.ReadLine());
                Option outOption;
                while(!Options.TryGetValue(optionIn, out outOption))
                {
                    Console.WriteLine("Zle wpisana opcja");
                    Console.WriteLine("Wprowadz jeszcze raz: ");
                    optionIn = Convert.ToInt32(Console.ReadLine());
                }
                CurrentOption = outOption;
               
                Console.WriteLine("Wybrales/as poprawnie napoj");

                Console.WriteLine("Czy chcesz cukier?");
                Console.WriteLine("0. Nie");
                Console.WriteLine("1. Tak");
                int sugarBoolIn = Convert.ToInt32(Console.ReadLine());
                if (sugarBoolIn.Equals(1))
                {
                    Console.WriteLine("Ile cukru [0-100]: ");
                    int sugarIn = Convert.ToInt32(Console.ReadLine());
                    Sugar = sugarIn;
                }

                Console.WriteLine("Czy chcesz mleko?");
                Console.WriteLine("0. Nie");
                Console.WriteLine("1. Tak");
                int milkBoolIn = Convert.ToInt32(Console.ReadLine());
                if (milkBoolIn.Equals(1))
                {
                    Console.WriteLine("Ile mleka [0-100]: ");
                    int milkIn = Convert.ToInt32(Console.ReadLine());
                    Milk = milkIn;
                }
            }
        }
    }
}