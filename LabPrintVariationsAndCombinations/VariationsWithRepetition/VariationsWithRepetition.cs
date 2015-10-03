using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class VariationsWithRepetition
{
    static void Main()
    {
        Console.Write("Size of set n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Elements from set k: ");
        int k = int.Parse(Console.ReadLine());
        int[] array = new int[k];

        GenerateVariations(array, n);
    }

    private static void GenerateVariations(int[] array, int sizeOfSet, int index = 0)
    {
        if (index >= array.Length)
        {
            Print(array);
        }
        else
        {
            for (int i = 1; i <= sizeOfSet; i++)
            {
                array[index] = i;
                GenerateVariations(array, sizeOfSet, index + 1);
            }
        }
    }

    private static void Print(int[] array)
    {
        Console.WriteLine("({0})", string.Join(", ", array));
    }
}
