class SumTime
{
    static void Main()
    {
        string[] time1 = Console.ReadLine().Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries);
        string[] time2 = Console.ReadLine().Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
        int minutes = int.Parse(time1[time1.Length - 1]) + int.Parse(time2[time2.Length - 1]);
        int hours = int.Parse(time1[time1.Length - 2]) + int.Parse(time2[time2.Length - 2]);
        int days = 0;
        if (time1.Length == 3)
        {
            days += int.Parse(time1[0]);
        }
        if (time2.Length == 3)
        {
            days += int.Parse(time2[0]);
        }
        while (minutes > 59)
        {
            hours++;
            minutes -= 60;
        }
        while (hours > 23)
        {
            days++;
            hours -= 24;
        }
        if (days != 0)
        {
            Console.Write(days + "::");
        }
        Console.Write("{0}:", hours);
        Console.WriteLine("{0}", minutes.ToString().PadLeft(2,'0'));
    }
}