using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class Touch : ITouch, IDevice
    {
        private List<Option> Options;
        private string Name;
        private int Sugar = 0;
        private int Milk = 0;

        private Option CurrentOption;

        public Touch()
        {
            this.Options = new List<Option>();
            this.Name = "Brak";
        }
        public Touch(string name)
        {
            this.Options = new List<Option>();
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Nazwa jest pusta lub nullem");
            }
            this.Name = name;
        }

        public void AddOption(Option option)
        {
            if (option.Equals(null))
            {
                throw new ArgumentNullException("opcja jest nullem");

            }
            this.Options.Add(option);
            Console.WriteLine(string.Format("Dodalo opcje {0}", option.GetName()));
        }
        public Option GetOption(string name)
        {
            Option result = this.Options.Where(x => x.GetName().Equals(name)).FirstOrDefault();
            if (result == null)
            {
                throw new KeyNotFoundException("Nie znalazlo opcji o danej nazwie.");
            }
            return result;
        }
        public Option GetCurrentOption()
        {
            if(CurrentOption == null)
            {
                throw new NullReferenceException("Nie wybrano żadnej opcji, dlatego aktualna opcja jest pusta.");
            }
            return this.CurrentOption;
        }
        public int GetSugar()
        {
            return this.Sugar;
        }
        public int GetMilk()
        {
            return this.Milk;
        }

        public bool SetSugar(int sugar)
        {
            bool result = true;
            if (sugar < 0 || sugar > 100)
            {
                result = false;
            }
            this.Sugar = sugar;
            return result;
        }
        public bool SetMilk(int milk)
        {
            bool result = true;
            if (milk < 0 || milk > 100)
            {
                result = false;
            }
            this.Milk = milk;
            return result;
        }
        private int CheckInLine(string ioType)
        {
            int result = 0;
            if (!int.TryParse(ioType, out result))
            {
                //Zostawia 0
            }
            return result;
        }
        public void ShowOptions()
        {
            int index = 0;
            var indexedOptions = new Dictionary<int, Option>();
            try
            {
                if (!this.Options.Any()) throw new IndexOutOfRangeException("Brak opcji do wyswietlenia");
                else
                {
                    Console.WriteLine("Ile cukru [0-100]: ");
                    int sugarIn = CheckInLine(Console.ReadLine());
                    while (!SetSugar(sugarIn))
                    {
                        Console.WriteLine("Zle wpisany cukier");
                        Console.WriteLine("Wprowadz jeszcze raz: ");
                        sugarIn = CheckInLine(Console.ReadLine());
                    }

                    Console.WriteLine("Ile mleka [0-100]: ");
                    int milkIn = CheckInLine(Console.ReadLine());
                    while (!SetMilk(milkIn))
                    {
                        Console.WriteLine("Zle wpisane mleko");
                        Console.WriteLine("Wprowadz jeszcze raz: ");
                        milkIn = CheckInLine(Console.ReadLine());
                    }

                    foreach (var eachOption in this.Options)
                    {
                        Console.WriteLine(string.Format("{0}. {1}.", index, eachOption.GetName()));
                        indexedOptions.Add(index, eachOption);
                        index++;
                    }

                    Console.WriteLine("Ktora opcje napoju wybierasz: ");
                    Option optionOut;
                    bool isGoodOption = false;
                    int optionIn;
                    var optionReadLine = Console.ReadLine();
                    if (!string.IsNullOrEmpty(optionReadLine) && int.TryParse(optionReadLine, out optionIn))
                    {
                        if (indexedOptions.TryGetValue(optionIn, out optionOut))
                        {
                            this.CurrentOption = optionOut;
                            isGoodOption = true;
                        }
                    }
                    if (!isGoodOption)
                    {
                        while (true)
                        {
                            Console.WriteLine("Zle wpisana opcja");
                            Console.WriteLine("Wprowadz jeszcze raz: ");
                            optionReadLine = Console.ReadLine();
                            if (!string.IsNullOrEmpty(optionReadLine) && int.TryParse(optionReadLine, out optionIn))
                            {
                                if (indexedOptions.TryGetValue(optionIn, out optionOut))
                                {
                                    this.CurrentOption = optionOut;
                                    break;
                                }
                            }
                        }
                    }

                    Console.WriteLine("Wybrales/as poprawnie napoj");
                }
            }
            catch (IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException(e.Message);
            }
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