using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IToothpaste
    {
        private const int MinIngredientsNameLength = 4;
        private const int MaxIngredientsNameLength = 12;

        private readonly IList<string> ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType genderType, IList<string> ingredients)
            : base(name, brand, price, genderType)
        {
            this.ingredients = ingredients;
        }

        public string Ingredients
        {
            get { return string.Join(", ", ingredients); }
        }

        public override string Print()
        {
            return "  * Ingredients: " + this.Ingredients;
        }
    }
}
