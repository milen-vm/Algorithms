using System;
using System.Collections.Generic;
using System.Text;

class ShortestPathInMatrix
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int columns = int.Parse(Console.ReadLine());

        int[,] graph = new int[rows * columns, rows * columns];
        int[,] matrix = new int[rows, columns];

        // read matrix input
        for (int i = 0; i < rows; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = int.Parse(input[j]);
            }
        }

        // build graph
        int parentNode = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {                
                if ((col + 1) < columns)
                {
                    int rightChildNode = parentNode + 1;
                    int pathLength = matrix[row, col + 1];
                    graph[parentNode, rightChildNode] = pathLength;
                }

                if ((row + 1) < rows)
                {
                    int bottomChildNode = parentNode + columns;
                    int pathLength = matrix[row + 1, col];
                    graph[parentNode, bottomChildNode] = pathLength;
                }

                if ((col - 1) >= 0)
                {
                    int leftChildNode = parentNode - 1;
                    int pathLength = matrix[row, col - 1];
                    graph[parentNode, leftChildNode] = pathLength;
                }

                if ((row - 1) >= 0)
                {
                    int topChildNode = parentNode - columns;
                    int pathLength = matrix[row - 1, col];
                    graph[parentNode, topChildNode] = pathLength;
                }

                ++parentNode;
            }
        }

        var path = DijkstraAlgorithm(graph, 0, (columns * rows - 1));

        // build output
        int pathSum = 0;
        StringBuilder pathStrBuild = new StringBuilder();
        for(int i = path.Count - 1; i > 0; i--)
        {
            int node = path[i];
            int prevNode = path[i - 1];

            int pathValue = graph[prevNode, node];
            pathStrBuild.Insert(0, " " + pathValue);
            pathSum += pathValue;
        }

        pathStrBuild.Insert(0, graph[1, 0]);
        pathSum += graph[1, 0];

        Console.WriteLine("Length: {0}", pathSum);
        Console.Write("Path: {0}", pathStrBuild);
    }

    public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
    {
        int n = graph.GetLength(0);
        int[] distance = new int[n];
        for (int i = 0; i < n; i++)
        {
            distance[i] = int.MaxValue;
        }

        distance[0] = 0;

        bool[] used = new bool[n];
        int?[] previous = new int?[n];

        while (true)
        {
            int minDistance = int.MaxValue;
            int minNode = 0;
            for (int node = 0; node < n; node++)
            {
                if (!used[node] && distance[node] < minDistance)
                {
                    minDistance = distance[node];
                    minNode = node;
                }
            }

            if (minDistance == int.MaxValue)
            {
                break;
            }

            used[minNode] = true;

            for (int i = 0; i < n; i++)
            {
                if (graph[minNode, i] > 0)
                {
                    int newDistance = minDistance + graph[minNode, i];
                    if (distance[i] > newDistance)
                    {
                        distance[i] = newDistance;
                        previous[i] = minNode;
                    }
                }
            }
        }

        if (distance[destinationNode] == int.MaxValue)
        {
            return null;
        }

        var path = new List<int>();
        int? currentNode = destinationNode;

        while (currentNode != null)
        {
            path.Add(currentNode.Value);
            currentNode = previous[currentNode.Value];
        }

        path.Reverse();

        return path;
    }
}