using System;
using System.Collections.Generic;
using System.Linq;

class CyclesInGraph
{
    static Dictionary<string, List<string>> graph;

    static void Main()
    {
        ReadGraph();
        bool isAcyclic = IsGraphAcyclic();

        Console.WriteLine("Acyclic: {0}", isAcyclic ? "Yes" : "No");
    }

    private static void ReadGraph()
    {
        graph = new Dictionary<string, List<string>>();
        string input = Console.ReadLine();

        while(!string.IsNullOrEmpty(input))
        {
            var chars = input.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            string firstNode = chars[0];
            string secondNode = chars[1];

            if (!graph.ContainsKey(firstNode))
            {
                graph.Add(firstNode, new List<string>());
            }

            if (!graph.ContainsKey(secondNode))
            {
                graph.Add(secondNode, new List<string>());
            }

            graph[firstNode].Add(secondNode);
            graph[secondNode].Add(firstNode);

            input = Console.ReadLine();
        }
    }

    private static bool IsGraphAcyclic()
    {
        var predecessorsCount = new Dictionary<string, int>();
        foreach(var node in graph)
        {
            if (!predecessorsCount.ContainsKey(node.Key))
            {
                predecessorsCount[node.Key] = 0;
            }

            foreach(var childNode in node.Value)
            {
                if (!predecessorsCount.ContainsKey(childNode))
                {
                    predecessorsCount[childNode] = 0;
                }

                ++predecessorsCount[childNode];
            }
        }

        while (true)
        {
            string nodeToRemove = graph.Keys.FirstOrDefault(n => predecessorsCount[n] <= 1);
            if (nodeToRemove == null)
            {
                break;
            }

            foreach (var childNode in graph[nodeToRemove])
            {
                --predecessorsCount[childNode];
            }

            graph.Remove(nodeToRemove);
        }

        return graph.Count == 0;
    }
}
