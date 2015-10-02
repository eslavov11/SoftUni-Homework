using System;
    class SortArrayOfNumbersUsingSelectionSort
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            string[] arr = numbers.Split(' ');
            int[] intArr = Array.ConvertAll<string, int>(arr, int.Parse);

            int temp = 0;
            int sortCount = 0;
            while (true)
            {
                for (int i = 0; i < intArr.Length - 1; i++)
                {
                    if (intArr[i] > intArr[i + 1])
                    {
                        temp = intArr[i + 1];
                        intArr[i + 1] = intArr[i];
                        intArr[i] = temp;
                        sortCount++;
                    }
                }
                if (sortCount==0)
                {
                    break;
                }
                sortCount = 0;
            }

            for (int i = 0; i < intArr.Length; i++)
            {
                Console.Write(intArr[i] + " ");
            }
            Console.WriteLine();
        }
    }
