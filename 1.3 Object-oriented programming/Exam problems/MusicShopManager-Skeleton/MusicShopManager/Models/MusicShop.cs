using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class MusicShop : IMusicShop
    {
        private string name;
        private IList<IArticle> articles;

        public MusicShop(string name)
        {
            this.articles = new List<IArticle>();
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name is required.");
                }
                this.name = value;
            }
        }

        public IList<IArticle> Articles
        {
            get { return this.articles; }
            private set { this.articles = value; }
        }

        public void AddArticle(IArticle article)
        {
            this.Articles.Add(article);
        }

        public void RemoveArticle(IArticle article)
        {
            this.Articles.Remove(article);
        }

        public string ListArticles()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"===== {this.Name} =====");
            if (!Articles.Any())
            {
                output.AppendLine("The shop is empty. Come back soon.");
            }
            else
            {
                this.AddArticles(output);
            }

            return output.ToString();
        }

        private void AddArticles(StringBuilder output)
        {
            if (this.Articles.Any(a => a is IMicrophone))
            {
                output.AppendLine("----- Microphones -----");
                output.AppendLine(string.Join(Environment.NewLine, Articles.OrderBy(x => x.Make).ThenBy(x => x.Model).Where(a => a is IMicrophone)));
            }
            if (this.Articles.Any(a => a is IDrums))
            {
                output.AppendLine("----- Drums -----");
                output.AppendLine(string.Join(Environment.NewLine, Articles.OrderBy(x => x.Make).Where(a => a is IDrums)));
            }
            if (this.Articles.Any(a => a is IElectricGuitar))
            {
                output.AppendLine("----- Electric guitars -----");
                output.AppendLine(string.Join(Environment.NewLine, Articles.OrderBy(x => x.Make).Where(a => a is IElectricGuitar)));
            }
            if (this.Articles.Any(a => a is IAcousticGuitar))
            {
                output.AppendLine("----- Acoustic guitars -----");
                output.AppendLine(string.Join(Environment.NewLine, Articles.OrderBy(x => x.Make).Where(a => a is IAcousticGuitar)));
            }
            if (this.Articles.Any(a => a is IBassGuitar))
            {
                output.AppendLine("----- Bass guitars -----");
                output.AppendLine(string.Join(Environment.NewLine, Articles.OrderBy(x => x.Make).Where(a => a is IBassGuitar)));
            }
        }
    }
}
