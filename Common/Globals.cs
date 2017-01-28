using Logary;
using Logary.Configuration;
using Logary.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Globals
    {
        private LogManager instanceManager;

        public LogManager LogManager
        {
            get { return instanceManager; }
            set { instanceManager = value; }
        }

        public Globals()
        {
            this.LogManager = LogaryFactory.New("CoffeeMaker",
                with => with
                    .Target<TextWriter.Builder>("ConsoleOut",
                    conf => conf.Target.WriteTo(System.Console.Out, System.Console.Error)));
        }
    }
}