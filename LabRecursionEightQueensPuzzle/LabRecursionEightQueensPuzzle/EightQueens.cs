using System;
using System.Collections.Generic;
using System.IO;

class EightQueens
{
    const int Size = 8;
    static bool[,] cheesboard = new bool[Size, Size];
    static HashSet<int> attackedRows = new HashSet<int>();
    static HashSet<int> attackedColumns = new HashSet<int>();
    static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
    static HashSet<int> attackedRightDiagonals = new HashSet<int>();
    static int solutionsFound = 0;

    static void Main()
    {
        PutQueens(0);
        Console.WriteLine(solutionsFound);
    }

    static void PutQueens(int row)
    {
        if (row == Size)
        {
            PrintSolution();
            WriteSolutionToFile();
        }
        else
        {
            for (int col = 0; col < Size; col++)
            {
                if (CanPlaceQueen(row, col))
                {
                    MarkAllAttackedPositions(row, col);
                    PutQueens(row + 1);
                    UnmarkAllAttackedPositions(row, col);
                }
            }
        }
    }

    private static void UnmarkAllAttackedPositions(int row, int col)
    {
        attackedRows.Remove(row);
        attackedColumns.Remove(col);
        attackedLeftDiagonals.Remove(col - row);
        attackedRightDiagonals.Remove(col + row);
        cheesboard[row, col] = false;
    }

    private static void MarkAllAttackedPositions(int row, int col)
    {
        attackedRows.Add(row);
        attackedColumns.Add(col);
        attackedLeftDiagonals.Add(col - row);
        attackedRightDiagonals.Add(col + row);
        cheesboard[row, col] = true;
    }

    private static bool CanPlaceQueen(int row, int col)
    {
        bool positionOccupied =
            attackedRows.Contains(row) ||
            attackedColumns.Contains(col) ||
            attackedLeftDiagonals.Contains(col - row) ||
            attackedRightDiagonals.Contains(col + row);

        return !positionOccupied;
    }

    private static void PrintSolution()
    {
        for (int row = 0; row < Size; row++)
        {
            for (int col = 0; col < Size; col++)
            {
                string resultStr = cheesboard[row, col] ? "Q" : "-";
                Console.Write(resultStr);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        ++solutionsFound;
    }

    private static void WriteSolutionToFile()
    {
        var sw = new StreamWriter("../../solutions.txt", true);
        sw.WriteLine(solutionsFound);
        for (int row = 0; row < Size; row++)
        {
            for (int col = 0; col < Size; col++)
            {
                string resultStr = cheesboard[row, col] ? "Q" : "-";
                sw.Write(resultStr);
            }

            sw.WriteLine();
        }

        sw.WriteLine();
        sw.Close();
    }
}
