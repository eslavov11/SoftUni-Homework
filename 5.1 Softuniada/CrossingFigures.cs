using System;

class CrossingFigures
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = new[]
            {
                Console.ReadLine(),
                Console.ReadLine()
            };

            string re = input[1].StartsWith("r") ? input[1] : input[0];
            string ci = input[1].StartsWith("r") ? input[0] : input[1];

            string cirle = ci.Substring(7);
            string[] tokens = cirle.Substring(0, cirle.Length - 1)
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            decimal ox = decimal.Parse(tokens[0]);
            decimal oy = decimal.Parse(tokens[1]);
            decimal r = decimal.Parse(tokens[2]);

            string rect = re.Substring(10);
            string[] tokens2 = rect.Substring(0, rect.Length - 1)
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            decimal ax = decimal.Parse(tokens2[0]);
            decimal ay = decimal.Parse(tokens2[1]);
            decimal bx = decimal.Parse(tokens2[2]);
            decimal by = decimal.Parse(tokens2[3]);

            if (((ax - ox) * (ax - ox)
                + (ay - oy) * (ay - oy) <= r * r)
                && 
				((bx - ox) * (bx - ox)
                + (by - oy) * (by - oy) <= r * r))
            {
                Console.WriteLine("Rectangle inside circle");
                continue;
            }

            if (((ax - ox) * (ax - ox)
                + (ay - oy) * (ay - oy) > r * r)
                &&                 
                ((bx - ox) * (bx - ox)
                + (ay - oy) * (ay - oy) > r * r)
                &&
                ((bx - ox) * (bx - ox)
                + (ay - oy) * (ay - oy) > r * r)               
                &&
                ((bx - ox) * (bx - ox)
                + (by - oy) * (by - oy) > r * r)
                )
            {
                Console.WriteLine("Circle inside rectangle");
                continue;
            }

            if (((ax - ox) * (ax - ox) +
                (ay - oy) * (ay - oy) <= r * r)
                || 
				((bx - ox) * (bx - ox) +
                (by - oy) * (by - oy) <= r * r))
            {
                Console.WriteLine("Rectangle and circle cross");
                continue;
            }

            Console.WriteLine("Rectangle and circle do not cross");
        }
    }
}

//o The rectangle is inside the circle ? print “Rectangle inside circle”.
//o The circle is inside the rectangle ? print “Circle inside rectangle”.
//o The rectangle and the circle intersect ? print “Rectangle and circle cross”.
//o The rectangle and the circle do not intersect(and neither is inside the other) ? print “Rectangle
//and circle do not cross”.