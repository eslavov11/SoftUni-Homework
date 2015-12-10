using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager
{
    public class Restaurant : IRestaurant
    {
        private string name;
        private string location;
        private IList<IRecipe> recipes;

        public Restaurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
            this.recipes = new List<IRecipe>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Restaurant name cannot be empty!");
                }
                this.name = value;
            }
        }

        public string Location
        {
            get { return this.location; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Restaurant location cannot be empty!");
                }
                this.location = value;
            }
        }

        public IList<IRecipe> Recipes { get; }

        public void AddRecipe(IRecipe recipe)
        {
            this.recipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            this.recipes.Remove(recipe);
        }

        public string PrintMenu()
        {
            StringBuilder menu = new StringBuilder();
            menu.AppendLine($"***** {this.Name} - {this.Location} *****");
            if (!recipes.Any())
            {
                menu.Append("No recipes... yet");
            }
            else
            {
                var drinks = recipes.Where(x => x is IDrink);
                var salads = recipes.Where(x => x is ISalad);
                var mainCourses = recipes.Where(x => x is IMainCourse);
                var desserts = recipes.Where(x => x is IDessert);

                menu.Append(FormatRecipes("DRINKS", drinks));
                menu.Append(FormatRecipes("SALADS", salads));
                menu.Append(FormatRecipes("MAIN COURSES", mainCourses));
                menu.Append(FormatRecipes("DESSERTS", desserts));
            }
            return menu.ToString().TrimEnd('\r', '\n');
        }

        private StringBuilder FormatRecipes(string recipeName, IEnumerable<IRecipe> recipes)
        {
            var result = new StringBuilder();
            result.Append("");
            if (recipes.Any())
            {
                result.AppendLine($"~~~~~ {recipeName} ~~~~~")
                    .AppendLine(string.Join(Environment.NewLine, recipes));
            }
            return result;
        }
    }
}