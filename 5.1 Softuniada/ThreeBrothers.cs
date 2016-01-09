using System;

class ThreeBrothers
{
    static void GenPermutations(int[] arr, int index)
    {
        if (index == arr.Length)
        {
            if (Check(arr))
            {
               throw new ArgumentException();
            }
        }
        else
        {
            for (int i = index; i < arr.Length; i++)
            {
                int temp = arr[i];
                arr[i] = arr[index];
                arr[index] = temp;
                GenPermutations(arr, index + 1);
                temp = arr[i];
                arr[i] = arr[index];
                arr[index] = temp;
            }
        }
    }

    private static bool Check(int[] arr)
    {
        int sum1 = 0, sum2 = 0, sum3 = 0;
        for (int i = 0, j = (arr.Length - arr.Length / 3) / 2; i < (arr.Length - arr.Length/3)/2; i++, j++)
        {
            sum1 += arr[i];
            sum2 += arr[j];
        }
        for (int i = (arr.Length - arr.Length / 3); i < arr.Length; i++)
        {
            sum3 += arr[i];
        }
        
        return sum1 == sum2 && sum2 == sum3;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            try
            {
                GenPermutations(arr, 0);
                Console.WriteLine("No");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Yes");
            }
        }
    }
}
