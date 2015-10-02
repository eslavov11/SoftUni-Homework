using System;
class CategorizeNumbers
{
    static void Main(string[] args)
    {
        string numbers = Console.ReadLine();

        string[] arr = numbers.Split(' ');
        int roundCount = 0;
        int floatCount = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if ((Convert.ToDouble(arr[i]) % 1) != 0)
            {
                floatCount++;
            }
            else
            {
                roundCount++;
            }
        }
        int[] arrRound = new int[roundCount];
        double[] arrFloat = new double[floatCount];
        for (int i = 0, numFloat = 0, numRound = 0; i < arr.Length; i++)
        {
            if ((Convert.ToDouble(arr[i]) % 1) != 0)
            {
                arrFloat[numFloat] = Convert.ToDouble(arr[i]);
                numFloat++;
            }
            else
            {
                string number = "";
                foreach (var item in arr[i])
                {
                    if (item == ',')
                    {
                        break;
                    }
                    number += item;
                }
                arrRound[numRound] = Convert.ToInt32(number);
                numRound++;
            }
        }

        Array.Sort(arrRound);
        Array.Sort(arrFloat);

        double sumRound = 0;
        double sumFloat = 0;
        double avgRound = 0;
        double avgFloat = 0;

        for (int i = 0; i < arrRound.Length; i++)
        {
            sumRound += arrRound[i];
        }
        for (int i = 0; i < arrFloat.Length; i++)
        {
            sumFloat += arrFloat[i];
        }

        avgFloat = sumFloat / arrFloat.Length;
        avgRound = sumRound / arrRound.Length;

        if (floatCount == 0)
        {
            Console.Write("[0] -> min: 0, max: 0, sum: 0, avg: 0");
        }
        else
        {
            Console.Write('[');

            for (int i = 0; i < arrFloat.Length; i++)
            {
                if (arrFloat.Length - 1 == i)
                {
                    Console.Write(arrFloat[i]);
                    break;
                }
                Console.Write(arrFloat[i] + ", ");
            }
            Console.Write("] -> ");
            Console.Write("min: " + arrFloat[0] + ", max: " + arrFloat[arrFloat.Length - 1] + ", sum: " + sumFloat + ", avg: " + avgFloat);

        }
        Console.WriteLine();

        if (roundCount == 0)
        {
            Console.Write("[0] -> min: 0, max: 0, sum: 0, avg: 0");
        }
        else
        {
            Console.Write('[');
            for (int i = 0; i < arrRound.Length; i++)
            {
                if (arrRound.Length - 1 == i)
                {
                    Console.Write(arrRound[i]);
                    break;
                }
                Console.Write(arrRound[i] + ", ");
            }
            Console.Write("] -> ");
            Console.Write("min: " + arrRound[0] + ", max: " + arrRound[arrRound.Length - 1] + ", sum: " + sumRound + ", avg: " + avgRound);
        }
        Console.WriteLine();
    }
}

//Input
//1,2 -4 5,00 12211 93,003 4 2,2	

//Output
//[1.2, 93.003, 2.2] -> min: 1.2, max: 93.003, sum: 96.403, avg: 32.13
//[-4, 5, 12211, 4] - > min: -4, max: 12211, sum: 12216, avg: 3054.00
