using System;
using System.Collections.Generic;

namespace Lesson8_Task1
{
    class Program
    {
        static void BucketSort(ref int[] array)
        {
            if (array == null || array.Length < 2)
            {
                return;
            }

            int min = array[0];
            int max = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }

                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            var bucket = new List<int>[max - min + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            for (int i = 0; i < array.Length; i++)
            {
                bucket[array[i] - min].Add(array[i]);
            }

            int pos = 0;

            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        array[pos] = bucket[i][j];
                        pos++;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            var enterArray = new int[] { 13, 1, 34, 118, 92, 6, 8, 777, 888, 666, 555, 222, 1112, 1111, 53, 0, 1, 78, 99, 32, 6, 3, 4, 8, 8, 9, 16218, 31, 323, 0, 123 };

            Console.WriteLine("=====================");
            Console.WriteLine("ARRAY BEFORE SORTING:");
            Console.WriteLine();

            for (int i = 0; i < enterArray.Length; i++)
            {
                Console.WriteLine($"{enterArray[i]}");
            }

            var checker = new Checker[5];
            checker[0] = new Checker()
            {
                InputA = 777,
                ExpectedValue = 777,
            };

            checker[1] = new Checker()
            {
                InputA = 888,
                ExpectedValue = 888,
            };

            checker[2] = new Checker()
            {
                InputA = 666,
                ExpectedValue = 666,
            };

            checker[3] = new Checker()
            {
                InputA = 555,
                ExpectedValue = 555,
            };

            checker[4] = new Checker()
            {
                InputA = 222,
                ExpectedValue = 222,
            };

            BucketSort(ref enterArray);

            Console.WriteLine();
            Console.WriteLine("=====================");
            Console.WriteLine("BUCKED SORT:");
            Console.WriteLine();

            for (int i = 0; i < enterArray.Length; i++)
            {
                Console.WriteLine($"{enterArray[i]}");
            }

            Console.ReadKey();
        }
    }
}
