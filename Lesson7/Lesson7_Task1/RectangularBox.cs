using System;

namespace Lesson7_Task1
{
    public class RectangularBox
    {
        public RectangularBox(int row, int column)
        {
            N = row;
            M = column;
        }

        public int N { get; set; }
        
        public int M { get; set; }

        /// <summary>
        /// Представляет метод вывода поля
        /// </summary>
        /// <param name="map"></param>
        public void PrintBox(int[,] map)
        {
            Console.WriteLine("Amount of roots:");
            Console.WriteLine();

            for (int i = 0; i < M; i++)
            {
                Console.Write("---+");
            }

            Console.WriteLine();

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    var result = map[i, j];
                    
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                    
                    if (map[i, j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.Write("{0, 3}", result);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|");
                Console.Write("\r\n");
            }

            for (int i = 0; i < M; i++)
            {
                Console.Write("+---");
            }
        }

        /// <summary>
        /// Представляет метод вывода карты
        /// </summary>
        /// <param name="board"></param>
        /// <param name="obstacleOn"></param>
        /// <returns></returns>
        public int[,] GetBoxWithObstacles(RectangularBox box, int obstacleOn = 1)
        {
            int[,] map = new int[N, M];
            int[,] barrier = new int[N, M];

            for (int j = 0; j < M; j++)
            {
                map[0, j] = 1;
            }

            for (int i = 1; i < N; i++)
            {
                map[i, 0] = 1;

                for (int j = 1; j < M; j++)
                {
                    if (obstacleOn == 1)
                    {
                        barrier[i, j] = 1;
                        barrier[4, 2] = 0;
                        barrier[2, 4] = 0;
                        barrier[2, 6] = 0;
                    }

                    if (obstacleOn == 0)
                    {
                        barrier[i, j] = 1;
                        barrier[4, 2] = 1;
                        barrier[2, 4] = 1;
                        barrier[2, 6] = 1;
                    }

                    if (barrier[i, j] == 1)
                    {
                        map[i, j] = map[i, j - 1] + map[i - 1, j];
                    }
                }
            }

            return map;
        }
    }
}
