using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantManager.Interfaces;
using RestaurantManager.Models;

namespace RestaurantManager
{
    public class Drink : Recipe, IDrink
    {
        private const MetricUnit DefaultDrinkMetricUnit = MetricUnit.Milliliters;
        private const int MaxDrinkCalories = 100;

        public Drink(string name,
            decimal price,
            int calories,
            int quantityPerServing,
            int timeToPrepare,
            bool isCarbonated)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.IsCarbonated = isCarbonated;
        }

        public override MetricUnit Unit
        {
            get { return DefaultDrinkMetricUnit; }
        }

        public bool IsCarbonated { get; }

        public override int Calories
        {
            get { return base.Calories; }
            set
            {
                if (value > MaxDrinkCalories)
                {
                    throw new ArgumentException("Invalid calories for a drink!");
                }
                base.Calories = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + "Carbonated: " + (this.IsCarbonated ? "yes" : "no");
        }


    }
}