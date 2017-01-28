using CoffeeMake.Includes.Types.ComponentType;
using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class Component : IComponent
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Pusta nazwa");
                }
                _name = value;
            }
        }
        private IComponentType Type;
        private bool Grindable;
        private float Temperature;


        public Component()
        {
            this._name = "brak";
            this.Type = new Dry();
            this.Grindable = false;
            this.Temperature = 0;
        }
        public Component(string name, IComponentType type, bool grindable)
        {
            if (string.IsNullOrEmpty(name) || type.Equals(null))
            {
                throw new ArgumentNullException("Pusta nazwa lub typ jest nullem");
            }
            if(type.GetType().IsEquivalentTo(new Liquid().GetType()))
            {
                if (grindable) throw new ArgumentException("Ciecz nie moze byc mielona.");
            }

            this._name = name;
            this.Type = type;
            this.Grindable = grindable;
        }
        public IComponentType GetComponentType()
        {
            return this.Type;
        }

        public void SetComponentType(IComponentType type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("Typ jest nullem");
            }
            this.Type = type;
        }

        public void SetGrindable(bool grindable)
        {
            this.Grindable = grindable;
        }

        public bool GetGrindable()
        {
            return this.Grindable;
        }

        public void SetTemperature(float temperature)
        {
            if(temperature < 0)
            {
                throw new ArgumentException("Temperatura jest za niska");
            }
            this.Temperature = temperature;
        }

        public float GetTemperature()
        {
            return Temperature;
        }
    }
}
