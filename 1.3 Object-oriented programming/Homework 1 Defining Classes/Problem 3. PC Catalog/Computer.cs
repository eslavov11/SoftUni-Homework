using System;
using System.Collections.Generic;
using System.Linq;

public class Computer : IComparable
{
    private string name;
    private List<Component> components;

    public Computer(string name, List<Component> components)
    {
        this.Name = name;
        this.Components = components;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid name!");
            }
            this.name = value;
        }
    }

    public List<Component> Components
    {
        get
        {
            return this.components;
        }

        set
        {
            if (value.Count == 0)
            {
                throw new ArgumentNullException("components", "Computer should contain at least one component.");
            }

            this.components = value;
        }
    }

    public decimal Price
    {
        get { return CalculatePrice(this); }
    }

    public void AddComponent(Component component)
    {
        var list = this.Components;
        list.Add(component);
        this.Components = list;
    }

    public override string ToString()
    {
        string result = string.Empty;
        result += string.Format("Computer's name: {0}\n", this.Name);
        result = this.Components.Aggregate(result, (current, component) =>
                current + string.Format("\t{0} ({1:c2})\r\n",
                component.Name,
                component.Price));
        result += string.Format("Computer's price: {0}\n", this.Price);
        return result;
    }

    public static decimal CalculatePrice(Computer pc)
    {
        return pc.components.Sum(component => component.Price);
    }

    public int CompareTo(object obj)
    {
        var pc = (Computer)obj;
        return this.Price.CompareTo(pc.Price);
    }
}

