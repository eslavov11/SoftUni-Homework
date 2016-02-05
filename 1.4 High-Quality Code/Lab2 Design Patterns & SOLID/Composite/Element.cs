namespace DOMBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Element
    {
        private readonly string type;
        private IList<Element> elements;
        private static int totalSpaceCount;

        public Element(string type, params Element[] elements)
        {
            this.type = type;
            this.Elements = elements.ToList();
            totalSpaceCount = 0;
        }

        private IList<Element> Elements
        {
            get
            {
                return this.elements;
            }

            set
            {
                if (value != null)
                {
                    this.elements = value;
                }
            }
        }

        public void Add(Element element)
        {
            this.Elements.Add(element);
        }


        public void Remove(Element element)
        {
            this.Elements.Remove(element);
        }

        public string Display()
        {
            return this.InternalDisplay(totalSpaceCount);
        }

        private string InternalDisplay(int currentSpaceCount)
        {
            var result = new StringBuilder();
            totalSpaceCount++;
            result.AppendFormat(
                "{0}<{1}>{2}{3}{4}</{5}>",
                new string(' ', currentSpaceCount * 4),
                this.type,
                Environment.NewLine,
                this.DisplayChildrenElements(),
                new string(' ', currentSpaceCount * 4),
                this.type);
            totalSpaceCount = currentSpaceCount;

            return result.ToString();
        }

        private string DisplayChildrenElements()
        {
            var result = new StringBuilder();

            foreach (var element in this.Elements)
            {
                result.AppendLine(element.InternalDisplay(totalSpaceCount));
            }

            return result.ToString();
        }
    }
}
