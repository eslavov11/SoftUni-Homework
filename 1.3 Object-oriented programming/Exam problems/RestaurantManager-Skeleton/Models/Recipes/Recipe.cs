using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantManager.Interfaces;
using RestaurantManager.Models;

namespace RestaurantManager
{
    public abstract class Recipe : IRecipe
    {
        private string name;
        private decimal price;
        private int calories;
        private int quantityPerServing;
        private int timeToPrepare;

        protected Recipe(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.QuantityPerServing = quantityPerServing;
            this.TimeToPrepare = timeToPrepare;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Recipe name cannot be empty!");
                }
                this.name = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0.0m)
                {
                    throw new ArgumentException("Recipe price cannot be a negative number!");
                }
                this.price = value;
            }
        }

        public virtual int Calories
        {
            get { return this.calories; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Recipe calories cannot be a negative number!");
                }
                this.calories = value;
            }
        }

        public int QuantityPerServing
        {
            get { return this.quantityPerServing; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Recipe quantity cannot be a negative number!");
                }
                this.quantityPerServing = value;
            }
        }

        public virtual MetricUnit Unit { get; }

        public int TimeToPrepare
        {
            get { return this.timeToPrepare; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Recipe time to prepare cannot be a negative number!");
                }
                this.timeToPrepare = value;
            }
        }

        public override string ToString()
        {
            string unit = this.Unit == MetricUnit.Grams ? "g" : "ml";
            return $"==  {this.Name} == ${$"{this.Price:F2}"}"
                   + Environment.NewLine +
                   $"Per serving: {this.QuantityPerServing} {unit}, {this.Calories} kcal"
                   + Environment.NewLine +
                   $"Ready in {this.TimeToPrepare} minutes";
        }
    }
}