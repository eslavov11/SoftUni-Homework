using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager
{
    public class Salad : Meal, ISalad
    {
        private const bool DefaultIsSaladVegan = true;

        public Salad(
            string name,
            decimal price,
            int calories,
            int quantityPerServing,
            int timeToPrepare,
            bool containsPasta)
            : base(name, price, calories, quantityPerServing, timeToPrepare, DefaultIsSaladVegan)
        {
            this.ContainsPasta = containsPasta;
        }

        public bool ContainsPasta { get; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + "Contains pasta: "
                   + (this.ContainsPasta ? "yes" : "no");
        }
    }
}