using System;
using BenchmarkDotNet.Attributes;

namespace Lesson3
{
    public class DistanceSearchBenchmarks
    {
        private DistanceSearch _test = new DistanceSearch(new Size<float>(1000, 1000), 2);

        [Benchmark]
        public void RefTypeByFloat()
        {
            _test.GetDistance(_test.PointsClassFloat[0], _test.PointsClassFloat[1]);
        }

        [Benchmark]
        public void ValueTypeByFloat()
        {
            _test.GetDistance(_test.PointsStructFloat[0], _test.PointsStructFloat[0]);
        }

        [Benchmark]
        public void ValueTypeInDouble()
        {
            _test.GetDistance(_test.PointsStructDouble[0], _test.PointsStructDouble[0]);
        }

        [Benchmark]
        public void ValueTypeInFloatSqrtless()
        {
            _test.GetDistanceSqrtless(_test.PointsStructFloat[0], _test.PointsStructFloat[0]);
        }
    }
}
