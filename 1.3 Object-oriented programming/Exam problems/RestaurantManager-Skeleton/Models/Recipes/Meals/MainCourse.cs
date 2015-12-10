using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantManager.Interfaces;
using RestaurantManager.Models;

namespace RestaurantManager
{
    public class MainCourse : Meal, IMainCourse
    {
        public MainCourse(
            string name,
            decimal price,
            int calories,
            int quantityPerServing,
            int timeToPrepare,
            bool isVegan,
            string type) 
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.Type = (MainCourseType)Enum.Parse(typeof(MainCourseType), type);
        }

        public MainCourseType Type { get; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + "Type: " + this.Type;
        }
    }
}