using System;
using System.Collections.Generic;
using System.Linq;

class TowerOfHanoi
{
    private static int stepsTaken = 0;
    private static Stack<int> source;
    private static readonly Stack<int> destination = new Stack<int>();
    private static readonly Stack<int> spare = new Stack<int>();

    static void Main()
    {
        Console.Write("Number of disks: ");
        int numberOfDisks = int.Parse(Console.ReadLine());
        source = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());
        PrintPegs();
        MoveDisks(numberOfDisks, source, destination, spare);
    }

    private static void MoveDisks(int bottomDisk, Stack<int>sourceRod, Stack<int>destinationRod, Stack<int>spareRod)
    {
        if (bottomDisk == 1)
        {
            ++stepsTaken;
            destinationRod.Push(sourceRod.Pop());
            Console.WriteLine("Step #{0}: Mved disk: {1}", stepsTaken, bottomDisk);
            PrintPegs();
        }
        else
        {
            MoveDisks(bottomDisk - 1, sourceRod, spareRod, destinationRod);
            ++stepsTaken;
            destinationRod.Push(sourceRod.Pop());
            Console.WriteLine("Steps {0}: Moved disk: {1}", stepsTaken, bottomDisk);
            PrintPegs();
            MoveDisks(bottomDisk - 1, spareRod, destinationRod, sourceRod);
        }
    }

    private static void PrintPegs()
    {
        Console.WriteLine("Source: {0}", string.Join(", ", source));
        Console.WriteLine("Destination: {0}", string.Join(", ", destination));
        Console.WriteLine("Spare: {0}", string.Join(", ", spare));
        Console.WriteLine();
    }
}
