using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5.HTMLDispatcher
{
    public static class HTMLDispatcher
    {
        public static string CreateImage(string source, string alt, string title)
        {
            ElementBuilder image = new ElementBuilder("img");
            image.AddAttribute("src", source);
            image.AddAttribute("alt", alt);
            image.AddAttribute("title", title);

            return image.ToString();
        }

        public static string CreateURL(string url, string text, string title)
        {
            ElementBuilder image = new ElementBuilder("a");
            image.AddAttribute("url", url);
            image.AddContent(text);
            image.AddAttribute("title", title);

            return image.ToString();
        }

        public static string CreateInput(string type, string name, string value)
        {
            ElementBuilder image = new ElementBuilder("a");
            image.AddAttribute("type", type);
            image.AddAttribute("name", name);
            image.AddAttribute("value", value);

            return image.ToString();
        }
    }
}
