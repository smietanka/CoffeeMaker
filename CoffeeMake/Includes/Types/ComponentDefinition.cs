using CoffeeMake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMake.Includes.Types
{
    public class ComponentDefinition
    {
        private string ComponentName;
        private int Temperature = 0;
        private int Amount;
        public ComponentDefinition()
        {
            this.ComponentName = "";
            this.Temperature = 0;
            this.Amount = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="component">Składnik</param>
        /// <param name="temperature">Temperatura. Musi być większa od 0</param>
        /// <param name="amount">Ilość. Musi być większa od 0</param>
        public ComponentDefinition(string component, int temperature, int amount)
        {
            if (string.IsNullOrEmpty(component) || temperature < 0 || amount < 0)
            {
                throw new ArgumentException("Któryś z parametrów jest zły.");
            }
            this.Temperature = temperature;
            this.Amount = amount;
            this.ComponentName = component;
        }
        public ComponentDefinition(string component, int amount)
        {
            if (string.IsNullOrEmpty(component) || amount < 0)
            {
                throw new ArgumentException("Któryś z parametrów jest zły.");
            }
            this.Amount = amount;
            this.ComponentName = component;
        }
        public void SetTemperature(int temperature)
        {
            if (temperature < 0)
            {
                throw new ArgumentException("Ujemny parametr");
            }
            this.Temperature = temperature;
        }
        public void SetComponent(string component)
        {
            if(string.IsNullOrEmpty(component))
            {
                throw new ArgumentNullException("Składnik jest nullem");
            }
            this.ComponentName = component;
        }
        public void SetAmount(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Ujemny parametr");
            }
            this.Amount = amount;
        }
        public string GetComponent()
        {
            return this.ComponentName;
        }
        public int GetTemperature()
        {
            return this.Temperature;
        }
        public int GetAmount()
        {
            return this.Amount;
        }
    }
}
