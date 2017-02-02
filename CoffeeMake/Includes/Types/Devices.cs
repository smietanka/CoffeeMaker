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
        /// <summary>
        /// Młynek
        /// </summary>
        public IGrinder Grinder { get; private set; }
        /// <summary>
        /// Głowica
        /// </summary>
        public IHead Head { get; private set; }
        /// <summary>
        /// Grzałka
        /// </summary>
        public IHeater Heater { get; private set; }
        /// <summary>
        /// Pompa
        /// </summary>
        public IPump Pump { get; private set; }

        /// <summary>
        /// Tworzy obiekt oraz inicjalizuje podstawowe urzadzenia w ekspresie.
        /// </summary>
        public Devices()
        {
            this.Grinder = new Grinder();
            this.Head = new Head();
            this.Pump = new Pump(this.Head);
            this.Heater = new Heater();
        }
    }
}