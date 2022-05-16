using System;

namespace Lesson6_Task1
{
    public class Edge
    {
        public Edge (Vertex from, Vertex to, int weight = 1)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        
        public Vertex From { get; set; }
        
        public Vertex To { get; set; }
        
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{From}, {To}";
        }
    }
}
