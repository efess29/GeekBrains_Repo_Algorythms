using System;

namespace Lesson6_Task1
{
    public class Vertex
    {
        public Vertex(int number)
        {
            Number = number;
        }

        public bool Visited { get; set; }
        
        public int Number { get; set; }
        
        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
