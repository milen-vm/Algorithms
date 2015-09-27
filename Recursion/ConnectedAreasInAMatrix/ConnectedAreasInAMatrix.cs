using System;
using System.Collections.Generic;
using System.Linq;

class ConnectedAreasInAMatrix
{
    private static int areaSize = 0;
    private static char[,] matrix =
    //{
    //    {' ',' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
    //    {' ',' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
    //    {' ',' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
    //    {' ',' ', ' ', ' ', '*', ' ', '*', ' ', ' '}
    //};
    {
        {'*',' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
        {'*',' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
        {'*',' ', ' ', '*', '*', '*', '*', '*', ' ', ' '},
        {'*',' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
        {'*',' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '}
    };

    static void Main()
    {
        var findedAreas = new SortedSet<Area>();
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == ' ')
                {
                    GetConnectedAreaSize(row, col);
                    var area = new Area(row, col, areaSize);
                    findedAreas.Add(area);
                    areaSize = 0;
                }
            }
        }

        if (findedAreas.Any())
        {
            Console.WriteLine("Total areas found: {0}", findedAreas.Count);
            int number = 0;
            foreach (var area in findedAreas)
            {
                ++number;
                Console.WriteLine("Area #{0} at {1}", number, area.ToString());
            }
        }
    }

    private static void GetConnectedAreaSize(int row, int col)
    {
        if (!InRange(row, col))
        {
            return;
        }

        if (matrix[row, col] != ' ')
        {
            return;
        }

        matrix[row, col] = 'x';
        ++areaSize;

        GetConnectedAreaSize(row, col + 1);   // right
        GetConnectedAreaSize(row + 1, col);   // down
        GetConnectedAreaSize(row, col - 1);   // left
        GetConnectedAreaSize(row - 1, col);   // up
    }

    private static bool InRange(int row, int col)
    {
        bool rowInRange = row >= 0 && row < matrix.GetLength(0);
        bool colInRange = col >= 0 && col < matrix.GetLength(1);

        return rowInRange && colInRange;
    }
}
