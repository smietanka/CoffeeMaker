using CoffeeMake.Includes.Types.ComponentType;
using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types.FDevices
{
    public class Pump : IPump
    {
        private string Name;
        private IComponentType ComponentType;
        public Pump()
        {
            this.Name = "Brak";
            this.ComponentType = new Dry();
        }
        public Pump(string name, IComponentType type)
        {
            if (string.IsNullOrEmpty(name) || type == null)
            {
                throw new ArgumentNullException("Nazwa lub typ jest pusty lub null");
            }
            this.Name = name;
            this.ComponentType = type;
        }
        public void SetComponentType(IComponentType type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("Typ jest pusty lub null");
            }
            this.ComponentType = type;
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