using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using RestaurantManager.Interfaces;
using RestaurantManager.Models;

namespace RestaurantManager
{
    public abstract class Meal : Recipe, IMeal
    {
        private const MetricUnit DefaultMealMetricUnit = MetricUnit.Grams;

        protected Meal (string name,
            decimal price,
            int calories,
            int quantityPerServing,
            int timeToPrepare,
            bool isVegan) 
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.IsVegan = isVegan;
        }

        public bool IsVegan { get; protected set; }

        public override MetricUnit Unit
        {
            get { return DefaultMealMetricUnit; }
        }

        public void ToggleVegan()
        {
            this.IsVegan = !IsVegan;
        }

        public override string ToString()
        {
            var vegan = IsVegan ? "[VEGAN] " : "";

            return vegan + base.ToString();
        }
    }
}