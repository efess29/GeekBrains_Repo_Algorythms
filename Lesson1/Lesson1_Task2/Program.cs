using System;

namespace Lesson1_Task2
{
    class Program
    {
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;  
            //O(C)
            for (int i = 0; i < inputArray.Length; i++)             //O(N)
            {
                for (int j = 0; j < inputArray.Length; j++)         //O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++)     //O(N)
                    {
                        int y = 0;                                  //O(C)

                        if (j != 0)                                 //O(1)
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y;       //O(1)
                    }
                }
            }

            return sum;                                             //O(1)
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Asymptotic complexity of this algorithm is: O(N*N*N) = O(N3)");
            Console.ReadKey();
        }
    }
}
