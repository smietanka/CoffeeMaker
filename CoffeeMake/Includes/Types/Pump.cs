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
        /// <summary>
        /// Tworzy obiekt z referencja do glowicy
        /// </summary>
        /// <param name="head">Glowica</param>
        /// <exception cref="ArgumentNullException">W momencie gdy glowica jest null</exception>
        public Pump(IHead head)
        {
            if(head == null)
            {
                throw new ArgumentNullException("Glowica jest nullem");
            }
            this.head = head;
        }

        /// <summary>
        /// Pompuje skladnik do glowicy
        /// </summary>
        /// <param name="component">Skladnik</param>
        public void Pumping(Component component)
        {
            this.head.Add(component);
        }
    }
}