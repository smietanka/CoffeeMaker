﻿using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types.Tank
{
    public class LiquidTank : Tank
    {
        public LiquidTank(Component component)
            : base(component)
        {

        }
        public override Component Component
        {
            get
            {
                return base.Component;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Składnik jest nullem.");
                }
                if (!value.Type.Equals(ComponentType.LIQUID))
                {
                    throw new ArgumentException("Skladnik nie jest przeznaczony do tego zbiornika");
                }
                base.Component = value;
            }
        }
    }
}