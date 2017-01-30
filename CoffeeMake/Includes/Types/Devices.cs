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
        private IGrinder _grinder;

        public IGrinder Gridner
        {
            get
            {
                if (_grinder == null)
                {
                    throw new NullReferenceException("Młynek nie został stworzony.");
                } 
                return _grinder;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Młynek jest nullem.");
                }
                _grinder = value;
            }
        }

        private IHead _head;

        public IHead Head
        {
            get
            {
                if (_head == null)
                {
                    throw new NullReferenceException("Głowica nie została stworzony.");
                } 
                return _head;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Głowica jest nullem.");
                } 
                _head = value;
            }
        }
        private IHeater _heater;

        public IHeater Heater
        {
            get
            {
                if (_heater == null)
                {
                    throw new NullReferenceException("Grzałka nie została stworzony.");
                } 
                return _heater;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Grzałka jest nullem.");
                } 
                _heater = value;
            }
        }

        private IPump _pump;

        public IPump Pump
        {
            get
            {
                if (_pump == null)
                {
                    throw new NullReferenceException("Pompa nie została stworzony.");
                } 
                return _pump;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Pompa jest nullem.");
                } _pump = value;
            }
        }
    }
}