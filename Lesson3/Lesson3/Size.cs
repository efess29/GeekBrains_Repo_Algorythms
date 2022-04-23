using System;

namespace Lesson3
{
    public class Size<T> : ICloneable
    {
        public Size(T height, T width)
        {
            Height = height;
            Width = width;
        }

        public T Height { get; }
        
        public T Width { get; }

        public object Clone() => new Size<T>(Height, Width);
    }
}
