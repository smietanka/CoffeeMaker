using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class Devices
    {
        public IGrinder Grinder { get; private set; }

        public IHead Head { get; private set; }

        public IHeater Heater { get; private set; }

        public IPump Pump { get; private set; }

        public Devices()
        {
            this.Grinder = new Grinder();
            this.Head = new Head();
            this.Pump = new Pump(this.Head);
            this.Heater = new Heater();
        }
    }
}