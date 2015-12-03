using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MostReliablePath
{
    static void Main()
    {
        Console.Write("Nodes: ");
        int nodes = int.Parse(Console.ReadLine());

        Console.Write("Path: ");
        string[] startEndNodes = Console.ReadLine().Split(new char[] { ' ', '-' },
            StringSplitOptions.RemoveEmptyEntries);
        int startNode = int.Parse(startEndNodes[0]);
        int endNode = int.Parse(startEndNodes[1]);

        Console.Write("Edges: ");
        int edges = int.Parse(Console.ReadLine());

        int[,] graph = new int[nodes, nodes];
        for(int i = 0; i < edges; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            int firstNode = int.Parse(input[0]);
            int secondNode = int.Parse(input[1]);
            int reliability = int.Parse(input[2]);

            graph[firstNode, secondNode] = reliability;
            graph[secondNode, firstNode] = reliability;
        }

        List<int> path = Dijkstra(graph, startNode, endNode);

        Console.WriteLine(string.Join(" -> ", path));
    }

    public static List<int> Dijkstra(int[,] graph, int startNode, int endNode)
    {
        int n = graph.GetLength(0);
        int[] reliability = new int[n];
        for (int i = 0; i < n; i++)
        {
            reliability[i] = int.MinValue;
        }

        reliability[0] = 100;

        bool[] used = new bool[n];
        int?[] previous = new int?[n];

        while (true)
        {
            int maxReliability = 0;
            int maxNode = 0;
            for (int node = 0; node < n; node++)
            {
                if (!used[node] && reliability[node] < maxReliability)
                {
                    maxReliability = reliability[node];
                    maxNode = node;
                }
            }

            if (maxReliability == int.MinValue)
            {
                break;
            }

            used[maxNode] = true;

            for (int i = 0; i < n; i++)
            {
                if (graph[maxNode, i] > 0)
                {
                    int newReliability = maxReliability + graph[maxNode, i];
                    if (reliability[i] > newReliability)
                    {
                        reliability[i] = newReliability;
                        previous[i] = maxNode;
                    }
                }
            }
        }

        if (reliability[endNode] == 0)
        {
            //return null;
        }

        var path = new List<int>();
        int? currentNode = endNode;

        while (currentNode != null)
        {
            path.Add(currentNode.Value);
            currentNode = previous[currentNode.Value];
        }

        path.Reverse();

        return path;
    }
}
