using System;
class Battery
{
    private string name;
    private byte batteryLife;

    public Battery(string name, byte batteryLife)
    {
        this.Name = name;
        this.BatteryLife = batteryLife;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if(value == string.Empty)
            {
                throw new ArgumentException("Incorrect battery name!");
            }
            this.name = value;
        }
    }

    public byte BatteryLife
    {
        get { return this.batteryLife; }
        set
        {
            if (value<0)
            {
                throw new ArgumentException("Incorrect battery life!");
            }
            this.batteryLife = value;
        }
    }

    public override string ToString()
    {
        string result = string.Empty;
        result += String.Format("Battery: {0}\n", this.Name);
        result += String.Format("Battery life: {0}", this.BatteryLife);
        return result;
    }

}

