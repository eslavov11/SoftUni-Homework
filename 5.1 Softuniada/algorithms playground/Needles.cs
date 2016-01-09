using System;

class Needles
{
    static void Main()
    {
        int[,] needles = new int[2, int.Parse(Console.ReadLine().Split(' ')[1])];
        int[] initSequence = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int[] arrTemp = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
		
        for (short i = 0; i < arrTemp.Length; i++) needles[0, i] = arrTemp[i];
		
        for (int i = 0, index = 0; i < needles.GetLength(1); i++)
        {
            for (int j = 0; j < initSequence.Length; j++, index++) { if(initSequence[j] >= needles[0,i]) break; }
            while (index != 0 && initSequence[index - 1] == 0) --index;
			
            needles[1, i] = index; index = 0;
        }
		
        var sb = new System.Text.StringBuilder();
		
        for (short i = 0; i < needles.GetLength(1); i++) sb.Append(needles[1, i] + " "); Console.WriteLine(sb);
    }
}