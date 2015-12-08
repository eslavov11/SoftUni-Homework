using System.Linq;
using System.Text;

namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;
    using FarmersCreed.Interfaces;

    public class Farm : GameObject, IFarm
    {
        private List<Plant> plants;
        private List<Animal> animals;
        private List<Product> products;  

        public Farm(string id)
            : base(id)
        {
            this.plants = new List<Plant>();
            this.animals = new List<Animal>();
            this.products = new List<Product>();
        }

        public List<Plant> Plants
        {
            get { return this.plants; }
        }

        public List<Animal> Animals
        {
            get { return this.animals; }
        }

        public List<Product> Products
        {
            get { return this.products; }
        }

        public void AddProduct(Product product)
        {
            var foundProduct = this.Products.FirstOrDefault(x => x.Id == product.Id);
            if (foundProduct != null)
            {
                foundProduct.Quantity += product.Quantity;
            }
            else
            {
                this.Products.Add(product);
            }
        }

        public void Exploit(IProductProduceable productProducer)
        {
            var product = productProducer.GetProduct();
            this.AddProduct(product);
        }

        public void Feed(Animal animal, IEdible edibleProduct, int productQuantity)
        {
            animal.Eat(edibleProduct, productQuantity);
            edibleProduct.Quantity -= productQuantity;
        }

        public void Water(Plant plant)
        {
            plant.Water();
        }

        public void UpdateFarmState()
        {
            foreach (var plant in Plants)
            {
                if (plant.HasGrown)
                {
                    plant.Wither();
                }
                else
                {
                    plant.Grow();
                }
            }

            foreach (var animal in Animals)
            {
                animal.Starve();
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendLine(
                    string.Join(
                        Environment.NewLine, 
                        this.Animals.Where(x => x.IsAlive)
                            .OrderBy(x => x.Id)))
                .AppendLine(
                    string.Join(
                        Environment.NewLine, 
                        this.Plants.Where(x => x.IsAlive)
                            .OrderBy(x => x.Health)
                            .ThenBy(x => x.Id)))
                .Append(
                    string.Join(
                        Environment.NewLine, 
                        this.Products.OrderBy(x => x.ProductType.ToString())
                            .ThenByDescending(x => x.Quantity)
                            .ThenBy(x => x.Id)));

            return result.ToString();
        }
    }
}
