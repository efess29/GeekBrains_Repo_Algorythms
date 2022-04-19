using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1_Task1
{
    class Program
    {
        static string CheckNumber(int n)
        {
            int d = 0;
            int i = 2;

            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                }

                i++;
            }

            if (d == 0)
            {
                return "A prime number.";
            }

            else
            {
                return "Not a prime number.";
            }
        }

        static string CheckNumberModified(int n)
        {
            if (n < 0 || n == 0)
            {
                return "Error: entered number is 0 or a negative number!";
            }

            int d = 0;
            int i = 2;

            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                }

                i++;
            }

            if (d == 0)
            {
                return "A prime number.";
            }

            else
            {
                return "Not a prime number.";
            }
        }

        static void Main(string[] args)
        {
            try
            {
                var test = new Checker[6];
                
                // На входе: 25, ожидание: не простое
                test[0] = new Checker()
                {
                    Number = 25,
                    StringValue = Checker.NonPrime,
                };
                
                // На входе: 44, ожидание: не простое
                test[1] = new Checker()
                {
                    Number = 44,
                    StringValue = Checker.NonPrime,
                };
                
                // На входе: 253, ожидание: не простое
                test[2] = new Checker()
                {
                    Number = 253,
                    StringValue = Checker.NonPrime,
                };
                
                // На входе: 898646, ожидание: не простое
                test[3] = new Checker()
                {
                    Number = 898646,
                    StringValue = Checker.NonPrime,
                };
                
                // На входе: 1, ожидание: простое
                test[4] = new Checker()
                {
                    Number = 1,
                    StringValue = Checker.Prime,
                };
                
                // На входе: 2, ожидание: простое
                test[5] = new Checker()
                {
                    Number = 2,
                    StringValue = Checker.Prime,
                };
                
                for (int i = 0; i < test.Length; i++)
                {
                    var result = CheckNumber(test[i].Number);
                
                    Console.WriteLine($"Entered number: {test[i].Number} - Status: {result}");
                }

                Console.WriteLine();
                Console.ReadKey();
            
                var test1 = new Checker[3];
                
                // На входе: -25, ожидание: ошибка
                test1[0] = new Checker()
                {
                    Number = -25,
                    StringValue = Checker.Error,
                };
                
                // На входе: 0, ожидание: ошибка
                test1[1] = new Checker()
                {
                    Number = 0,
                    StringValue = Checker.Error,
                };
                
                // На входе: 2, ожидание: простое
                test1[2] = new Checker()
                {
                    Number = 2,
                    StringValue = Checker.Prime,
                };
                
                for (int i = 0; i < test1.Length; i++)
                {
                    var result = CheckNumberModified(test1[i].Number);
                
                    Console.WriteLine($"Entered number: {test1[i].Number} - Status: {result}");
                }

                Console.WriteLine();
                Console.ReadKey();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            
        }
    }
}
