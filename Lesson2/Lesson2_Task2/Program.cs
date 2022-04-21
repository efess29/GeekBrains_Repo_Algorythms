using System;

namespace Lesson2_Task2
{
    class Program
    {
        /// <summary>
        /// Представляет метод двоичного поиска
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static int BinarySearch(int[] inputArray, int searchValue) // O(N)
        {
            Array.Sort(inputArray);

            int min = 0;
            int max = inputArray.Length - 1;

            // O(logN)
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }

                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }

                else
                {
                    min = min + 1;
                }
            }

            return -1;
        }

        // "Asymptotic complexity of this algorithm is: O(logN+N) = O (log N)"

        static void Main(string[] args)
        {
            int[] array = new int[]
            {
                9, 8, 7, 5, 6, 3, 4, 1, 2,
                11, 13, 12, 15, 14, 17, 16,
                19, 20, 18, 10, 2236, 434,
                75, 98, -1, 213, 423, 765,
                33, 1, 42, 09, -213, 43,
            };

            var checker = new Checker[5];

            // На входе: 8, ожидание: 10
            checker[0] = new Checker()
            {
                InputA = 8,
                ExpectedValue = 10,
            };

            // На входе: 2236, ожидание: 33
            checker[1] = new Checker()
            {
                InputA = 2236,
                ExpectedValue = 33,
            };

            // На входе: 75, ожидание: 27
            checker[2] = new Checker()
            {
                InputA = 75,
                ExpectedValue = 27,
            };

            // На входе: -1, ожидание: 1
            checker[3] = new Checker()
            {
                InputA = -1,
                ExpectedValue = 1,
            };

            // На входе: 999999, ожидание: не найдено
            checker[4] = new Checker()
            {
                InputA = 999999,
                ExpectedValue = -1,
            };

            Array.Sort(array);

            Console.WriteLine("Sorted array:");

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"index - [{i}]\tvalue - [{array[i]}]");
            }

            Console.WriteLine();
            Console.WriteLine("TEST");

            for (int i = 0; i < checker.Length; i++)
            {
                int indexOfSearchElement = BinarySearch(array, checker[i].InputA);

                if (indexOfSearchElement == -1)
                {
                    Console.WriteLine($"Entered value: {checker[i].InputA}\t\t\tItem not found.");
                }

                else
                {
                    Console.WriteLine($"Entered value: {checker[i].InputA}\t\t\tElement index in sorted array: {indexOfSearchElement}");
                }
            }

            Console.ReadKey();
        }
    }
}
