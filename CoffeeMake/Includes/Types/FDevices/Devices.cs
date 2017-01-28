using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types.FDevices
{
    public class Devices
    {
        private IList<IDevice> AllDevices { get; set; }
        public Devices()
        {
            AllDevices = new List<IDevice>();
        }
        public void Add(IDevice device)
        {
            if(device == null)
            {
                throw new ArgumentNullException("Podano null");
            }
            this.AllDevices.Add(device);
            Console.WriteLine(string.Format("Dodalo {0}", device.GetName()));
        }
        public void Remove(IDevice device)
        {
            this.AllDevices.Remove(device);
        }
        public IDevice Get(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Nazwa urządzenia jest pusta lub null");
            }
            IDevice device = this.AllDevices.Where(x => x.GetName().Equals(name)).FirstOrDefault();
            if(device == null)
            {
                throw new NullReferenceException("Nie znaleziono takiego urządzenia");
            }
            return device;
        }

        public IHead GetHead()
        {
            IHead head = this.AllDevices.OfType<IHead>().ToList<IHead>().FirstOrDefault();
            if (head == null)
            {
                throw new NullReferenceException("Nie znaleziono takiej glowicy");
            }
            return head;
        }
        public IGrinder GetGrinder()
        {
            IGrinder grind = this.AllDevices.OfType<IGrinder>().ToList<IGrinder>().FirstOrDefault();
            if(grind == null)
            {
                throw new NullReferenceException("Nie znaleziono takiego mlynka");
            }
            return grind;
        }
        public IHeater GetHeater()
        {
            IHeater heat = this.AllDevices.OfType<IHeater>().ToList<IHeater>().FirstOrDefault();
            if (heat == null)
            {
                throw new NullReferenceException("Nie znaleziono takiego mlynka");
            }
            return heat;
        }
    }
}