using System;
using System.Collections.Generic;

class DistanceBetweenVertices
{
    static Dictionary<Node, List<Node>> graph = new Dictionary<Node, List<Node>>()
    {
        { new Node(11), new List<Node>() { new Node(4) } },
        { new Node(4), new List<Node>() { new Node(12), new Node(1) } },
        { new Node(1), new List<Node>() { new Node(12), new Node(21), new Node(7) } },
        { new Node(7), new List<Node>() { new Node(21) } },
        { new Node(12), new List<Node>() { new Node(4), new Node(19) } },
        { new Node(19), new List<Node>() { new Node(1), new Node(21) } },
        { new Node(21), new List<Node>() { new Node(14), new Node(31) } },
        { new Node(14), new List<Node>() { new Node(14) } },
        { new Node(31), new List<Node>() { } },
    };

    static void Main()
    {
        var startNode = new Node(11);
        var endNode = new Node(14);
        int steps = FindStepsBetweenNodes(startNode, endNode);

        Console.WriteLine("{{{0}, {1}}} -> {2}", startNode.Value, endNode.Value, steps);
    }

    private static int FindStepsBetweenNodes(Node startNode, Node endNode)
    {
        if (!graph.ContainsKey(startNode))
        {
            throw new ArgumentOutOfRangeException("Graph do not contains start node with value: " + startNode.Value);
        }

        if (startNode.Equals(endNode))
        {
            return 0;
        }

        var nodes = new Queue<Node>();
        var visited = new HashSet<Node>();
        nodes.Enqueue(startNode);
        visited.Add(startNode);

        while (nodes.Count != 0)
        {
            var currentNode = nodes.Dequeue();

            foreach(var childNode in graph[currentNode])
            {
                if (!visited.Contains(childNode))
                {
                    childNode.Distance = currentNode.Distance + 1;
                    nodes.Enqueue(childNode);
                    visited.Add(childNode);

                    if (childNode.Equals(endNode))
                    {
                        return childNode.Distance;
                    }
                }
            }
        }

        return -1;
    }
}
