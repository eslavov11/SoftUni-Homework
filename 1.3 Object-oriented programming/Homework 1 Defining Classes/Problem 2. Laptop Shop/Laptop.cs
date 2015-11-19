using System;
class Laptop
{
    private string model;
    private decimal price;

    public Laptop(
        string model,
        string manufacturer,
        string processor,
        string ram,
        string graphicsCard,
        string HDD,
        string screen,
        decimal price,
        Battery battery)
    {
        this.Model = model;
        this.Manufacturer = manufacturer;
        this.Processor = processor;
        this.RAM = ram;
        this.GPU = graphicsCard;
        this.HDD = HDD;
        this.Screen = screen;
        this.Price = price;
        this.Battery = battery;
    }

    public Laptop(string model, string manufacturer, decimal price, string procesdor) :
        this(model, manufacturer, procesdor, null, null, null, null, price, null)
    {

    }


    public Laptop(string model, decimal price) : this(model, null, null, null, null, null, null, price, null)
    {

    }

    public string Model
    {
        get { return this.model; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid name!");
            }
            this.model = value;
        }
    }

    public string Manufacturer { set; get; }

    public string Processor { set; get; }

    public string RAM { set; get; }

    public string GPU { set; get; }

    public string HDD { set; get; }

    public string Screen { set; get; }

    public Battery Battery { set; get; }

    public decimal Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Price cannot be less than zero!");
            }
            this.price = value;
        }
    }

    public override string ToString()
    {
        string result = string.Empty;

        if (this.Model != null)
        {
            result += string.Format("Model: {0}\n", this.Model);
        }
        if (this.Manufacturer != null)
        {
            result += string.Format("Manufacturer: {0}\n", this.Manufacturer);
        }
        if (this.Processor != null)
        {
            result += string.Format("Processor: {0}\n", this.Processor);
        }
        if (this.RAM != null)
        {
            result += string.Format("RAM: {0}\n", this.RAM);
        }
        if (this.GPU != null)
        {
            result += string.Format("Graphics card: {0}\n", this.GPU);
        }
        if (this.HDD != null)
        {
            result += string.Format("HDD: {0}\n", this.HDD);
        }
        if (this.Screen != null)
        {
            result += string.Format("Screen: {0}\n", this.Screen);
        }
        if (this.Battery != null)
        {
            result += string.Format("Battery: {0}\n", this.Battery);
        }

        result += string.Format("Price: {0}\n", this.Price);

        return result;
    }
}
//    Define a class Laptop that holds the following information about a laptop device: 
//    model, manufacturer, processor, RAM, graphics card, HDD, screen, battery, battery
//    life in hours and price.
