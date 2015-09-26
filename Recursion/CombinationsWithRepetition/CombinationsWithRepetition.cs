using System;
class CombinationsWithRepetition
{
    static void Main()
    {
        int elementsCount;
        int elementsInCombination;
        do
        {
            Console.Write("Elements count: ");
            elementsCount = int.Parse(Console.ReadLine());
            Console.Write("Elements in conbination: ");
            elementsInCombination = int.Parse(Console.ReadLine());
        }
        while (elementsCount < elementsInCombination);

        int[] combinations = new int[elementsInCombination];
        GenerateCombinations(combinations, 0, 1, elementsCount);
    }

    private static void GenerateCombinations(int[] combinations, int index,int startNumber, int endNuber)
    {
        if (index >= combinations.Length)
        {
            Console.WriteLine("({0})", string.Join(" ", combinations));
        }
        else
        {
            for (int i = startNumber; i <= endNuber; i++)
            {
                combinations[index] = i;
                GenerateCombinations(combinations, index + 1, i, endNuber);
            }
        }
    }
}