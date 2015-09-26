using System;

class NestedLoopsToRecursion
{
    static void Main()
    {
        Console.Write("Loops count: ");
        int loopsCount = int.Parse(Console.ReadLine());
        int[] loopsVar = new int[loopsCount];
        NestedLoops(loopsCount, loopsVar, 0);
    }

    private static void NestedLoops(int count, int[] variables, int index)
    {
        if (index >= variables.Length)
        {
            Console.WriteLine(string.Join(" ", variables));
        }
        else
        {
            for (int i = 1; i <= count; i++)
            {
                variables[index] = i;
                NestedLoops(count, variables, index + 1);
            }
        }
    }
}
