using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager
{
    public class Dessert : Meal, IDessert
    {
        public Dessert(
            string name,
            decimal price,
            int calories,
            int quantityPerServing,
            int timeToPrepare,
            bool isVegan) 
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.WithSugar = true;
        }

        public bool WithSugar { get; set; }

        public void ToggleSugar()
        {
            this.WithSugar = !this.WithSugar;
        }

        public override string ToString()
        {
            var noSugar = WithSugar ? "" : "[NO SUGAR] ";

            return noSugar + base.ToString();
        }

        
    }
}