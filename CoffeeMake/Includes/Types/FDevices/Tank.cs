using CoffeeMake.Includes.Types.ComponentType;
using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types.FDevices
{
    public class Tank : ITank
    {
        private string Name;
        private float Capacity;
        private IComponentType ComponentType;
        private IComponent Component;

        public Tank()
        {
            this.Name = "Brak";
            this.Capacity = 0;
            this.ComponentType = new Dry();
            this.Component = new Component();
        }

        public Tank(string name, float capacity, IComponentType type, IComponent component)
        {
            if (type == null || component == null || capacity < 0 || string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Ktorys z parametrow jest bledny.");
            }

            if(!component.GetComponentType().Equals(type))
            {
                throw new ArgumentException("Typ zbiornika jest nie zgodny z typem składnika.");
            }

            if(!name.Equals(component.GetName()))
            {
                throw new ArgumentException("Nazwa zbiornika nie jest przeznaczona dla tego składnika. Składnikiem powinien być: " + name);
            }

            this.Name = name;
            this.Capacity = capacity;
            this.ComponentType = type;
            this.Component = component;
        }

        public float GetCapacity()
        {
            return this.Capacity;
        }

        public string GetName()
        {
            return this.Name;
        }

        public IComponentType GetComponentType()
        {
            return this.ComponentType;
        }

        public void RunJob()
        {
            throw new NotImplementedException();
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Pusta nazwa");
            }
            this.Name = name;
        }
        public void SetCapacity(float capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentNullException("Pojemnosc schowka mniejsza od 0");
            }
            this.Capacity = capacity;
        }

        public void SetComponentType(IComponentType type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("Typ jest nullem");
            }
            this.ComponentType = type;
        }

        public void RemoveContent(float content)
        {
            if (this.Capacity - content < 0 || content < 0)
            {
                throw new ArgumentException("Za duzo chcesz pobrac zawartosci lub ilosc zawartosci jest za mala.");
            }
            this.Capacity = this.Capacity - content;
        }
        public void AddContent(float content)
        {
            this.Capacity = this.Capacity + content;
        }

        public void ShowCapacityToConsole()
        {
            Console.WriteLine(string.Format("W ekspresie jest {0} ml {1}", this.GetCapacity(), this.GetName()));
        }

        public IComponent GetComponent()
        {
            return this.Component;
        }

        public void SetComponent(IComponent component)
        {
            if(component == null)
            {
                throw new ArgumentNullException("Składnik jest nullem.");
            }
            if(!component.GetComponentType().Equals(this.ComponentType) || !component.GetName().Equals(Name))
            {
                throw new ArgumentException("Składnik jest złym typem do zbiornika lub zbiornik jest przeznaczony dla innego składnika.");
            }
            this.Component = component;
        }
    }
}