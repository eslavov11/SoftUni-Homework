using System;
public class Component : IComparable
{
    private string name;
    private decimal price;

    public Component(string name, decimal price, string details)
    {
        this.Name = name;
        this.Price = price;
        this.Details = details;
    }

    public Component(string name, decimal price) : this(name, price, null)
    {

    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Incorrect name of component!");
            }
            this.name = value;
        }
    }

    public decimal Price
    {
        get { return this.price; }
        set
        {
            if (value<0)
            {
                throw new ArgumentException("Price of component cannot be below zero!");
            }
            this.price = value;
        }
    }

    public string Details { get; set; }

    public int CompareTo(object obj)
    {
        var component = (Component)obj;
        return this.Price.CompareTo(component.Price);
    }
}

