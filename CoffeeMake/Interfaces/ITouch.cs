using CoffeeMake.Includes.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Interfaces
{
    public interface ITouch
    {
        int Sugar { get; set; }
        int Milk { get; set; }
        Option CurrentOption { get; set; }

        void ShowOptions();
    }
}
