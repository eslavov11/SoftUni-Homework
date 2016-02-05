namespace DOMBuilder
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Element html = new Element("html", 
                            new Element("head"), 
                            new Element("body",
                                new Element("section",
                                    new Element("h3"),
                                    new Element("p")),
                                new Element("ul",
                                    new Element("li", 
                                        new Element("a")),
                                    new Element("li",
                                        new Element("a"))),
                                new Element("footer")));
            html.Add(new Element("script"));

            Console.WriteLine(html.Display());
        }
    }
}
