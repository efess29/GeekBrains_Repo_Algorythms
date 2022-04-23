using System;

namespace Lesson3
{
    class DistanceSearch
    {
        private PointClass<float>[] _pointsClassFloat;
        private PointClass<double>[] _pointsClassDouble;
        private PointStruct<float>[] _pointsStructFloat;
        private PointStruct<double>[] _pointsStructDouble;
        private Size<float> _workspace;

        public DistanceSearch(Size<float> workspace, PointClass<float>[] pointsClass, PointStruct<float>[] pointsStruct)
        {
            _workspace = (Size<float>)workspace.Clone();
            _pointsClassFloat = (PointClass<float>[])pointsClass.Clone();
            _pointsClassDouble = (PointClass<double>[])pointsClass.Clone();
            _pointsStructFloat = (PointStruct<float>[])pointsStruct.Clone();
            _pointsStructDouble = (PointStruct<double>[])pointsStruct.Clone();
        }

        public int PointsCount
        {
            get => _pointsClassFloat.Length;
            set
            {
                if (_pointsClassFloat.Length != value)
                    InitializeArraysPoints(value);
            }
        }

        public Size<float> Workspace
        {
            get => _workspace;
            set
            {
                if (Workspace.Height != value.Height || Workspace.Width != value.Width)
                {
                    _workspace = (Size<float>)value.Clone();
                    GeneratePoints(ref _pointsClassFloat);
                    GeneratePoints(ref _pointsClassDouble);
                    GeneratePoints(ref _pointsStructFloat);
                    GeneratePoints(ref _pointsStructDouble);
                }
            }
        }

        public PointClass<float>[] PointsClassFloat { get => _pointsClassFloat; }
        
        public PointClass<double>[] PointsClassDouble { get => _pointsClassDouble; }
        
        public PointStruct<float>[] PointsStructFloat { get => _pointsStructFloat; }
        
        public PointStruct<double>[] PointsStructDouble { get => _pointsStructDouble; }

        public DistanceSearch(Size<float> workspace, int pointsCount)
        {
            _workspace = (Size<float>)workspace.Clone();
            InitializeArraysPoints(pointsCount);
        }

        public void InitializeArraysPoints(int length)
        {
            _pointsClassFloat = new PointClass<float>[length];
            GeneratePoints(ref _pointsClassFloat);
            _pointsClassDouble = new PointClass<double>[length];
            GeneratePoints(ref _pointsClassDouble);
            _pointsStructFloat = new PointStruct<float>[length];
            GeneratePoints(ref _pointsStructFloat);
            _pointsStructDouble = new PointStruct<double>[length];
            GeneratePoints(ref _pointsStructFloat);
        }

        #region GetDistances

        public float GetDistance(PointClass<float> point_1, PointClass<float> point_2)
        {
            return (float)Math.Sqrt(Math.Pow(point_1.X - point_2.X, 2) + Math.Pow(point_1.Y - point_2.Y, 2));
        }

        public float GetDistance(PointStruct<float> point_1, PointStruct<float> point_2)
        {
            return (float)Math.Sqrt(Math.Pow(point_1.X - point_2.X, 2) + Math.Pow(point_1.Y - point_2.Y, 2));
        }

        public double GetDistance(PointClass<double> point_1, PointClass<double> point_2)
        {
            return (double)Math.Sqrt(Math.Pow(point_1.X - point_2.X, 2) + Math.Pow(point_1.Y - point_2.Y, 2));
        }

        public double GetDistance(PointStruct<double> point_1, PointStruct<double> point_2)
        {
            return (double)Math.Sqrt(Math.Pow(point_1.X - point_2.X, 2) + Math.Pow(point_1.Y - point_2.Y, 2));
        }

        public float GetDistanceSqrtless(PointClass<float> point_1, PointClass<float> point_2)
        {
            return (float)(Math.Pow(point_1.X - point_2.X, 2) + Math.Pow(point_1.Y - point_2.Y, 2));
        }

        public float GetDistanceSqrtless(PointStruct<float> point_1, PointStruct<float> point_2)
        {
            return (float)(Math.Pow(point_1.X - point_2.X, 2) + Math.Pow(point_1.Y - point_2.Y, 2));
        }

        public double GetDistanceSqrtless(PointClass<double> point_1, PointClass<double> point_2)
        {
            return (double)(Math.Pow(point_1.X - point_2.X, 2) + Math.Pow(point_1.Y - point_2.Y, 2));
        }

        public double GetDistanceSqrtless(PointStruct<double> point_1, PointStruct<double> point_2)
        {
            return (double)(Math.Pow(point_1.X - point_2.X, 2) + Math.Pow(point_1.Y - point_2.Y, 2));
        }

        #endregion

        #region GeneratePoints

        private void GeneratePoints(ref PointClass<float>[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = new PointClass<float>((float)random.Next((int)Workspace.Height), (float)random.Next((int)Workspace.Width));
        }

        private void GeneratePoints(ref PointClass<double>[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = new PointClass<double>((double)random.Next((int)Workspace.Height), (double)random.Next((int)Workspace.Width));
        }

        private void GeneratePoints(ref PointStruct<float>[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = new PointStruct<float>((float)random.Next((int)Workspace.Height), (float)random.Next((int)Workspace.Width));
        }

        private void GeneratePoints(ref PointStruct<double>[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = new PointStruct<double>((double)random.Next((int)Workspace.Height), (double)random.Next((int)Workspace.Width));
        }

        #endregion

    }
}
