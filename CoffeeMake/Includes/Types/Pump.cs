using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class Pump : IPump
    {
        private IHead head;
        public Pump(IHead head)
        {
            if(head == null)
            {
                throw new ArgumentNullException("Glowica jest nullem");
            }
            this.head = head;
        }

        public void Pumping(Component component)
        {
            this.head.Add(component);
        }
    }
}