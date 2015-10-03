using System;

class CombinationsWithRepetition
{
    static void Main()
    {
        Console.Write("Size of set n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Elements from set k: ");
        int k = int.Parse(Console.ReadLine());
        int[] array = new int[k];

        GenerateCombinations(array, n);
    }

    private static void GenerateCombinations(int[] array, int sizeOfSet, int index = 0, int startNum = 1)
    {
        if (index >= array.Length)
        {
            Print(array);
        }
        else
        {
            for (int i = startNum; i <= sizeOfSet; i++)
            {
                array[index] = i;
                GenerateCombinations(array, sizeOfSet, index + 1, startNum);
                startNum++;
            }
        }
    }

    private static void Print(int[] array)
    {
        Console.WriteLine("({0})", string.Join(", ", array));
    }
}