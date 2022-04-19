using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        public static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Use recursive method");
            Console.WriteLine("2. Use iteration method");
            Console.WriteLine("3. Use memorization method");
            Console.WriteLine("4. Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine();
                    Console.Write("Input number of terms for the Fibonacci series: ");
                    int n = Convert.ToInt32(Console.ReadLine());

                    Console.Write("\nThe Fibonacci (recursive) series of {0} terms is: ", n);
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("{0}  ", FindFibonacciRecursive(i));
                    }

                    Console.ReadLine();
                    return false;
                case "2":
                    Console.WriteLine();
                    Console.Write("Input number of terms for the Fibonacci series: ");
                    int n2 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("\nThe Fibonacci (iteration) series of {0} terms is: ", n2);
                    for (int i = 0; i < n2; i++)
                    {
                        Console.Write("{0}  ", FindFibonacciIteration(i));
                    }

                    Console.ReadLine();
                    return false;
                case "3":
                    Console.WriteLine();
                    Console.Write("Input number of terms for the Fibonacci series: ");
                    int n3 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("\nThe Fibonacci (memorization) series of {0} terms is: ", n3);
                    for (int i = 0; i < n3; i++)
                    {
                        Console.Write("{0}  ", FindFibonacciMemorization(i));
                    }

                    Console.ReadLine();
                    return false;
                case "4":
                    return false;
                default:
                    Console.WriteLine("Enter valid option!");
                    Console.ReadLine();
                    return true;
            }
        }

        /// <summary>
        /// Представляет рекурсивный метод вывода чисел Фибоначчи от 0 до n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int FindFibonacciRecursive(int n)
        {
            if (n == 0)
                return 0;

            else if (n == 1)
                return 1;

            else
                return FindFibonacciRecursive(n - 2) + FindFibonacciRecursive(n - 1);
        }

        /// <summary>
        /// Представляет итеративный метод вывода чисел Фибоначчи от 0 до n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int FindFibonacciIteration(int n)
        {
            int prev = 1;
            int result = 0;

            for (int i = 0; i < n; i++)
            {
                int temp = result;
                result = prev;
                prev += temp;
            }

            return result;
        }

        /// <summary>
        /// Представляет dictionary для хранения ("кэширования") ранее посчитанных значений
        /// </summary>
        static Dictionary<int, long> memo = new Dictionary<int, long>() { { 0, 0 }, { 1, 1 } };

        /// <summary>
        /// Представляет "кэшированный" метод вывода чисел Фибоначчи от 0 до n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static long FindFibonacciMemorization(int n)
        {
            if (memo.ContainsKey(n))
                return memo[n];

            var value = FindFibonacciMemorization(n - 2) + FindFibonacciMemorization(n - 1);

            memo[n] = value;

            return value;
        }
    }
}
