using System;

namespace Lesson3
{
    internal class PointClass<T> : ICloneable
    {
        public PointClass(T x, T y)
        {
            X = x;
            Y = y;
        }

        public T X { get; set; }
        
        public T Y { get; set; }

        public object Clone() => new PointClass<T>(X, Y);
    }

    internal struct PointStruct<T> : ICloneable
    {
        public PointStruct(T x, T y)
        {
            X = x;
            Y = y;
        }

        public T X { get; set; }

        public T Y { get; set; }

        public object Clone() => new PointStruct<T>(X, Y);
    }
}
