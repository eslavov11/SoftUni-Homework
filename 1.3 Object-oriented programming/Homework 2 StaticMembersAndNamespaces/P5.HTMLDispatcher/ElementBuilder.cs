using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5.HTMLDispatcher
{
    class ElementBuilder
    {
        private string element;
        
        public ElementBuilder(string attributeName)
        {
            this.Element = String.Format("<{0} ></{0}>", attributeName);
        }

        public string Element
        {
            get
            {
                return element;
            }

            set
            {
                this.element = value;
            }
        }

        public void AddAttribute(string attribute, string value)
        {
            this.Element = this.Element.Insert(
                this
                .Element
                .IndexOf('>'),
                String.Format(
                    "{0}=\"{1}\" ", attribute, value));
        }

        public void AddContent(string content)
        {
            this.Element = this
                .Element
                .Insert(
                this
                .Element
                .IndexOf('>')+1, content);
        }

        public static ElementBuilder operator *(ElementBuilder e1, int count)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                result.Append(e1.Element);
            }
            e1.Element = result.ToString();
            return e1;
        }

        public override string ToString()
        {
            return Element.ToString();
        }
    }
}
