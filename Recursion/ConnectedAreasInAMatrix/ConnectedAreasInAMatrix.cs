using System;
using System.Collections.Generic;
using System.Linq;

class ConnectedAreasInAMatrix
{
    private static Tuple<int, int> firstTraversableCell = new Tuple<int, int> (0, 0);
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
        FindFirstTraversableCell();

        while (firstTraversableCell != null)
        {
            FindConnectedAreas(firstTraversableCell.Item1, firstTraversableCell.Item2);
            var area = new Area()
            {
                StartRow = firstTraversableCell.Item1,
                StartCol = firstTraversableCell.Item2,
                Size = areaSize
            };

            findedAreas.Add(area);
            areaSize = 0;
            FindFirstTraversableCell();
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

    private static void FindFirstTraversableCell()
    {
        if (firstTraversableCell == null)
        {
            return;
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == ' ')
                {
                    firstTraversableCell = new Tuple<int, int>(row, col);
                    return;
                }
            }
        }

        firstTraversableCell = null;
    }

    private static void FindConnectedAreas(int row, int col)
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

        FindConnectedAreas(row, col + 1);   // right direction
        FindConnectedAreas(row + 1, col);   // down direction
        FindConnectedAreas(row, col - 1);   // left direction
        FindConnectedAreas(row - 1, col);   // up direction
    }

    private static bool InRange(int row, int col)
    {
        bool rowInRange = row >= 0 && row < matrix.GetLength(0);
        bool colInRange = col >= 0 && col < matrix.GetLength(1);

        return rowInRange && colInRange;
    }
}
