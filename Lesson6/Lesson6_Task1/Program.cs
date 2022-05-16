using System;

namespace Lesson6_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new MainGraph();

            var v1 = new Vertex(1);
            var v2 = new Vertex(2);
            var v3 = new Vertex(3);
            var v4 = new Vertex(4);
            var v5 = new Vertex(5);
            var v6 = new Vertex(6);
            var v7 = new Vertex(7);
            var v8 = new Vertex(8);

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);
            graph.AddVertex(v7);
            graph.AddVertex(v8);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
            graph.AddEdge(v2, v4);
            graph.AddEdge(v4, v5);
            graph.AddEdge(v1, v6);
            graph.AddEdge(v6, v7);
            graph.AddEdge(v6, v8);

            graph.PrintMatrix(graph);
            
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("Adjacency list");
            Console.WriteLine();

            graph.PrintVertex(v1);
            graph.PrintVertex(v2);
            graph.PrintVertex(v3);
            graph.PrintVertex(v4);
            graph.PrintVertex(v5);
            graph.PrintVertex(v6);
            graph.PrintVertex(v7);
            graph.PrintVertex(v8);

            Console.ReadKey();
            Console.Clear();

            // ========= TEST 1 ========= //
            var checker = new Checker[4];
            checker[0] = new Checker()
            {
                InputA = 8,
                InputB = v1,
                ExpectedValue = 8,
            };

            checker[1] = new Checker()
            {
                InputA = 4,
                InputB = v2,
                ExpectedValue = 4,
            };

            checker[2] = new Checker()
            {
                InputA = 2,
                InputB = v1,
                ExpectedValue = 2,
            };

            checker[3] = new Checker()
            {
                InputA = 5,
                InputB = v2,
                ExpectedValue = 5,
            };

            // ========= TEST BFS ========= //

            for (int i = 0; i < checker.Length; i++)
            {
                Console.WriteLine($"Element search starts from: [{checker[i].InputB}] - Expecting: [{checker[i].InputA}]");
                
                graph.BFSSearch(checker[i].InputB, checker[i].InputA);
                
                Console.ReadKey();
                Console.Clear();

                v1.Visited = false;
                v2.Visited = false;
                v3.Visited = false;
                v4.Visited = false;
                v5.Visited = false;
                v6.Visited = false;
                v7.Visited = false;
                v8.Visited = false;
            }

            // ========= TEST DFS ========= //

            for (int i = 0; i < checker.Length; i++)
            {
                Console.WriteLine($"Element search starts from: [{checker[i].InputB}] - Expecting: [{checker[i].InputA}]");
                
                graph.DFSSearch(checker[i].InputB, checker[i].InputA);
                
                Console.ReadKey();
                Console.Clear();

                v1.Visited = false;
                v2.Visited = false;
                v3.Visited = false;
                v4.Visited = false;
                v5.Visited = false;
                v6.Visited = false;
                v7.Visited = false;
                v8.Visited = false;
            }

            Console.ReadKey();
        }
    }
}
