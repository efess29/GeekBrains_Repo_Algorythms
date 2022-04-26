using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Lesson4_Task1
{
    public class BenchmarkClass
    {
        private string[] _stringArray;
        private HashSet<string> _hashSet;
        private StringGenerator _generateString;
        private Random _rnd;
        private int _items = 10001;


        private string RandomString { get; set; }

        private int Index { get; set; }

        public BenchmarkClass()
        {
            _hashSet = new HashSet<string>();
            _stringArray = new string[10001];

            _rnd = new Random(345);
            _generateString = new StringGenerator();

            AddValues();
        }

        public void AddValues()
        {
            for (int i = 0; i < _items; i++)
            {
                var str = _generateString.GenerateStrings(_rnd, 10);
                _stringArray[i] = str;
                _hashSet.Add(str);
            }
        }

        [Benchmark]
        public void StringArrayTest()
        {
            Index = _rnd.Next(_items);
            RandomString = _stringArray[Index];
            
            for (int i = 0; i < _items; i++)
            {
                if (_stringArray[i] == RandomString)
                {
                    return;
                }
            }
        }

        [Benchmark]
        public void HashSetTest()
        {
            Index = _rnd.Next(_items);
            RandomString = _stringArray[Index];
            for (int i = 0; i < _items; i++)
            {
                if (_hashSet.Contains(RandomString))
                {
                    return;
                }
            }
        }
    }
}
