using System;
using System.Linq;

class Permutations
{
    private static int countOfPermutations = 0;
    static void Main()
    {
        Console.Write("n: ");
        int n = int.Parse(Console.ReadLine());
        var array = Enumerable.Range(1, n).ToArray();

        Permute(array);

        Console.WriteLine("Total permutations: {0}", countOfPermutations);
    }

    private static void Permute(int[] array, int startIndex = 0)
    {
        if (startIndex >= array.Length - 1)
        {
            Console.WriteLine(string.Join(", ", array));
            ++countOfPermutations;
        }
        else
        {
            for (int i = startIndex; i < array.Length; i++)
            {
                Swap(ref array[startIndex], ref array[i]);
                Permute(array, startIndex + 1);
                Swap(ref array[i], ref array[startIndex]);
            }
        }
    }

    private static void Swap(ref int a, ref int b)
    {
        if(a == b)
        {
            return;
        }

        b = a + b;
        a = b - a;
        b = b - a;
    }
}
