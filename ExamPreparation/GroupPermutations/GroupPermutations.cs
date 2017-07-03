using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class GroupPermutations
{
    private static Dictionary<string, StringBuilder> leters;

    static void Main()
    {
        string input = Console.ReadLine();
        leters = new Dictionary<string, StringBuilder>();

        for (int i = 0; i < input.Length; i++)
        {
            string leter = input[i].ToString();

            if (!leters.ContainsKey(leter))
            {
                leters[leter] = new StringBuilder();
            }

            leters[leter].Append(leter);
        }

        string[] leterKeys = leters.Keys.ToArray();

        GeneratePermutations(leterKeys, 0);
    }

    static void GeneratePermutations(string[] arr, int index)
    {
        if (index >= arr.Length)
        {
            Print(arr);
        }
        else
        {
            GeneratePermutations(arr, index + 1);
            for (int i = index + 1; i < arr.Length; i++)
            {
                Swap(ref arr[index], ref arr[i]);
                GeneratePermutations(arr, index + 1);
                Swap(ref arr[index], ref arr[i]);
            }
        }

    }

    static void Print(string[] arr)
    {
        StringBuilder result = new StringBuilder();

        foreach (var item in arr)
        {
            result.Append(leters[item]);
        }

        Console.WriteLine(result);
    }

    static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }
}
