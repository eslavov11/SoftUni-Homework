using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5.HTMLDispatcher
{
    class HTMLDispatcherTest
    {
        static void Main(string[] args)
        {
            ElementBuilder build = new ElementBuilder("div");
            build.AddAttribute("font", "Ariel");
            build.AddContent("HomePage!");
            Console.WriteLine(build * 3);
            Console.WriteLine();


            Console.WriteLine(HTMLDispatcher.CreateImage("picture.jpg", "this is my image", "The image"));
            Console.WriteLine(HTMLDispatcher.CreateURL("www.softuni.bg", "softuni's homepage", "softuni.bg"));
            Console.WriteLine(HTMLDispatcher.CreateInput("submit", "Submit button", "Click me!"));
        }
    }
}
