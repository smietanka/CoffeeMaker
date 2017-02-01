using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types.Tank
{
    public class TankFactory
    {
        public static ITank CreateTank(Component paramComp)
        {
            if(paramComp == null)
            {
                throw new ArgumentNullException("Skladnik jest null");
            }
            switch(paramComp.Type)
            {
                case ComponentType.DRY:
                    return new DryTank(paramComp);
                case ComponentType.LIQUID:
                    return new LiquidTank(paramComp);
                default:
                    throw new ArgumentException("Nie znaleziono zbiornika dla takiego typu skladnika.");
            }
        }
    }
}
