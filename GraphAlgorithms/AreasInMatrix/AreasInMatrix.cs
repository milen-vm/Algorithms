using System;
using System.Collections.Generic;
using System.Linq;

class AreasInMatrix
{
    static string[,] matrix = new string[,]
    {
        { "a", "s", "s", "s", "a", "a", "d", "a", "s" },
        { "a", "d", "s", "d", "a", "s", "d", "a", "d" },
        { "s", "d", "s", "d", "a", "d", "s", "a", "s" },
        { "s", "d", "a", "s", "d", "s", "d", "s", "a" },
        { "s", "s", "s", "s", "a", "s", "d", "d", "d" }
    };

    static void Main()
    {
        var areas  = FindAreasInMatrix();
        int areasCount = areas.Values.Sum();

        Console.WriteLine("Areas: " + areasCount);

        foreach(var area in areas)
        {
            Console.WriteLine("Letter '{0}' -> {1}", area.Key, area.Value);
        }
    }

    private static Dictionary<string, int> FindAreasInMatrix()
    {
        bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
        Dictionary<string, int> areas = new Dictionary<string, int>();

        for(int row = 0; row < matrix.GetLength(0); row++)
        {
            for(int col = 0; col < matrix.GetLength(1); col++)
            {
                if (!visited[row, col])
                {
                    string simbol = matrix[row, col];
                    DFS(simbol, row, col, visited);

                    if (!areas.ContainsKey(simbol))
                    {
                        areas.Add(simbol, 0);
                    }

                    ++areas[simbol];
                }
            }
        }

        return areas;
    }

    private static void DFS(string simbol, int row, int col, bool[,] visited)
    {
        if(!IsInArea(simbol, row, col) || visited[row, col])
        {
            return;
        }

        visited[row, col] = true;

        DFS(simbol, row, col + 1, visited);     // right
        DFS(simbol, row + 1, col, visited);     // down
        DFS(simbol, row, col - 1, visited);     // left
        DFS(simbol, row - 1, col, visited);     // up
    }

    private static bool IsInArea(string simbol, int row, int col)
    {
        bool inRow = row >= 0 && row < matrix.GetLength(0);
        bool inCol = col >= 0 && col < matrix.GetLength(1);

        if (inRow && inCol)
        {
            return matrix[row, col] == simbol;
        }

        return false;
    }
}
