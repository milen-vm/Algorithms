using System;
using System.Collections.Generic;

class ExtendCableNetwork
{
    private static int budget;
    private static List<Edge> graph;
    private static bool[] connectedNodes;

    static void Main()
    {
        ReadInput();

        int usedBudget = 0;
        graph.Sort();

        foreach(var edge in graph)
        {
            if(usedBudget + edge.Weight > budget)
            {
                break;
            }

            if(connectedNodes[edge.StartNode] != connectedNodes[edge.EndNode])
            {
                connectedNodes[edge.StartNode] = true;
                connectedNodes[edge.EndNode] = true;
                usedBudget += edge.Weight;
                Console.WriteLine(edge);
            }
        }

        Console.WriteLine("Budget used: {0}", usedBudget);
    }

    private static void ReadInput()
    {
        Console.Write("Budget: ");
        budget = int.Parse(Console.ReadLine());
        Console.Write("Nodes: ");
        int nodes = int.Parse(Console.ReadLine());
        Console.Write("Edges: ");
        int edges = int.Parse(Console.ReadLine());

        graph = new List<Edge>();
        connectedNodes = new bool[nodes];

        for(int i = 0; i < edges; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            Edge edge = new Edge(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));
            graph.Add(edge);

            if(input.Length == 4 && input[3] == "connected")
            {
                connectedNodes[edge.StartNode] = true;
                connectedNodes[edge.EndNode] = true;
            }
        }
    }
}
