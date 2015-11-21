namespace Kurskal
{
    using System;
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            edges.Sort();
            // Initialize parents
            var parrent = new int[numberOfVertices];
            for(int i = 0; i < numberOfVertices; i++)
            {
                parrent[i] = i;
            }

            var spaningTree = new List<Edge>();
            foreach(var edge in edges)
            {
                int rootStartNode = FindRoot(edge.StartNode, parrent);
                int rootEndNode = FindRoot(edge.EndNode, parrent);
                if(rootStartNode != rootEndNode)
                {
                    spaningTree.Add(edge);
                    parrent[rootEndNode] = rootStartNode;
                }
            }

            return spaningTree;
        }

        public static int FindRoot(int node, int[] parent)
        {
            int root = node;
            while(parent[root] != root)
            {
                root = parent[root];
            }

            return root;
        }
    }
}
