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
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Nazwa jest pusta lub nullem.");
                }
                _name = value;
            }
        }
        public ComponentType Type { get; set; }

        public Pump(string name, ComponentType type)
        {
            Name = name;
            Type = type;
        }

        public void Pumping(Component component)
        {
            throw new NotImplementedException();
        }
    }
}