using System;
using System.Collections.Generic;

namespace Lesson6_Task1
{
    public class MainGraph
    {
        List<Vertex> Vertexes = new List<Vertex>();
        List<Edge> Edges = new List<Edge>();

        public int VertexCount => Vertexes.Count;
        
        public int EdgesCount => Edges.Count;

        /// <summary>
        /// Представляет метод добавления вершин в коллекцию
        /// </summary>
        /// <param name="vertex"></param>
        public void AddVertex(Vertex vertex)
        {
            Vertexes.Add(vertex);
        }

        /// <summary>
        /// Представляет метод добавления ребер в коллекцию
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void AddEdge(Vertex from, Vertex to)
        {
            var edge = new Edge(from, to);
            Edges.Add(edge);
        }

        /// <summary>
        /// Представляет метод поиска графа в глубину
        /// </summary>
        /// <param name="start"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public List<Vertex> DFSSearch(Vertex start, int searchValue)
        {
            Console.WriteLine();
            Console.WriteLine("DFS Search");
            Console.WriteLine();

            var buffer = new Stack<Vertex>();
            List<Vertex> returnArray = new List<Vertex>();

            buffer.Push(start);

            if (buffer == null)
            {
                return null;
            }

            while (buffer.Count != 0)
            {
                var element = buffer.Pop();

                if (element.Number == searchValue)
                {
                    element.Visited = true;
                    Console.WriteLine();
                    Console.WriteLine($"Required element: [{element.Number}] Visited: [{element.Visited}] ");
                    break;
                }

                returnArray.Add(element);
                element.Visited = true;
                
                Console.WriteLine($"--> [{element.Number}] Visited: [{element.Visited}]");

                for (int i = 0; i < Edges.Count; i++)
                {
                    if (element == Edges[i].From)
                    {
                        if (Edges[i].To.Visited != true)
                        {
                            buffer.Push(Edges[i].To);
                        }
                    }
                }
            }

            return returnArray;
        }

        /// <summary>
        /// Представляет волновой метод поиска графа
        /// </summary>
        /// <param name="start"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public List<Vertex> BFSSearch(Vertex start, int searchValue)
        {
            Console.WriteLine();
            Console.WriteLine("BFS Search");
            Console.WriteLine();

            var buffer = new Queue<Vertex>();
            var returnArray = new List<Vertex>();
            buffer.Enqueue(start);

            if (buffer == null)
            {
                return null;
            }

            while (buffer.Count != 0)
            {
                var element = buffer.Dequeue();

                if (element.Number == searchValue)
                {
                    element.Visited = true;
                    Console.WriteLine();
                    Console.WriteLine($"Required element: [{element.Number}] Visited: [{element.Visited}] ");
                    break;
                }

                else
                {
                    foreach (var edgesNear in Edges)
                    {
                        if (element == edgesNear.From)
                        {
                            buffer.Enqueue(edgesNear.To);
                        }
                    }

                    if (element.Visited != true)
                    {
                        returnArray.Add(element);
                        element.Visited = true;
                        Console.WriteLine($"--> [{element.Number}] [{element.Visited}]");
                    }
                }
            }

            return returnArray;
        }

        /// <summary>
        /// Представляет метод вывода списка смежностей
        /// </summary>
        /// <param name="vertex"></param>
        public void PrintVertex(Vertex vertex)
        {
            Console.Write($"[{vertex.Number}] -> ");
            
            foreach (var v in GetVertex(vertex))
            {
                Console.Write($"[{v}];");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Представляет метод получения вершины
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        private HashSet<Vertex> GetVertex(Vertex vertex)
        {
            var result = new HashSet<Vertex>();

            foreach (var edge in Edges)
            {
                if (vertex == edge.From)
                {
                    result.Add(edge.To);
                }
            }

            return result;
        }

        /// <summary>
        /// Представляет метод вывода матрицы смежности
        /// </summary>
        /// <param name="graph"></param>
        public void PrintMatrix(MainGraph graph)
        {
            Console.WriteLine("Adjacency matrix");
            Console.WriteLine();

            var matrix = graph.GetMatrix();
            
            for (int i = 0; i < graph.VertexCount; i++)
            {
                Console.Write($"{i + 1} |");
                
                for (int j = 0; j < graph.VertexCount; j++)
                {
                    Console.Write(string.Format("{0, 3}", $"{matrix[i, j]}"));
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Представляет метод вывода матрицы смежности
        /// </summary>
        /// <returns></returns>
        private int[,] GetMatrix()
        {
            var matrix = new int[Vertexes.Count, Vertexes.Count];

            foreach (var edge in Edges)
            {
                var row = edge.From.Number - 1;
                var column = edge.To.Number - 1;

                matrix[row, column] = edge.Weight;
            }
            return matrix;
        }
    }
}
