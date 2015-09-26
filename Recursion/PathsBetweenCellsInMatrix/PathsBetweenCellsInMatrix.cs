using System;
using System.Collections.Generic;

class PathsBetweenCellsInMatrix
{
    private static int totalPaths = 0;
    private static List<char?> path = new List<char?>();
    private static char[,] matrix =
    {
        {' ', ' ', ' ', ' '},
        {' ', '*', '*', ' '},
        {' ', '*', '*', ' '},
        {' ', '*', 'e', ' '},
        {' ', ' ', ' ', ' '},
    };
    //{
    //    {' ', ' ', ' ', ' ', ' ', ' '},
    //    {' ', '*', '*', ' ', '*', ' '},
    //    {' ', '*', '*', ' ', '*', ' '},
    //    {' ', '*', 'e', ' ', ' ', ' '},
    //    {' ', ' ', ' ', '*', ' ', ' '},
    //};

    static void Main()
    {
        FindPathBetweenCells(0, 0);
        Console.WriteLine("Total paths found: {0}", totalPaths);
    }

    private static void FindPathBetweenCells(int row, int col, char? direction = null)
    {
        if (!InRange(row, col))
        {
            return;
        }

        if (matrix[row, col] == 'e')
        {
            path.Add(direction);
            Console.WriteLine(string.Join("", path));
            path.RemoveAt(path.Count - 1);
            ++totalPaths;

            return;
        }

        if (matrix[row, col] != ' ')
        {
            return;
        }

        matrix[row, col] = 's';
        path.Add(direction);
        
        FindPathBetweenCells(row, col + 1, 'R');
        FindPathBetweenCells(row + 1, col, 'D');
        FindPathBetweenCells(row, col - 1, 'L');
        FindPathBetweenCells(row - 1, col, 'U');

        matrix[row, col] = ' ';
        path.RemoveAt(path.Count - 1);
    }

    private static bool InRange(int row, int col)
    {
        bool rowInRange = row >= 0 && row < matrix.GetLength(0);
        bool colInRange = col >= 0 && col < matrix.GetLength(1);

        return rowInRange && colInRange;
    }
}
