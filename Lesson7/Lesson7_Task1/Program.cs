using System;

namespace Lesson7_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var checker = new Checker[6];

            checker[0] = new Checker()
            {
                InputA = 7,
                InputB = 7,
                InputC = 1,
                ExpectedValueA = 7,
                ExpectedValueB = 7,
                ExpectedString = "with obstacle",
            };

            checker[1] = new Checker()
            {
                InputA = 7,
                InputB = 7,
                InputC = 0,
                ExpectedValueA = 7,
                ExpectedValueB = 7,
                ExpectedString = "without obstacle",
            };

            checker[2] = new Checker()
            {
                InputA = 5,
                InputB = 7,
                InputC = 1,
                ExpectedValueA = 5,
                ExpectedValueB = 7,
                ExpectedString = "with obstacle",
            };

            checker[3] = new Checker()
            {
                InputA = 5,
                InputB = 7,
                InputC = 0,
                ExpectedValueA = 5,
                ExpectedValueB = 7,
                ExpectedString = "without obstacle",
            };

            checker[4] = new Checker()
            {
                InputA = 5,
                InputB = 8,
                InputC = 1,
                ExpectedValueA = 5,
                ExpectedValueB = 8,
                ExpectedString = "with obstacle",
            };

            checker[5] = new Checker()
            {
                InputA = 5,
                InputB = 8,
                InputC = 0,
                ExpectedValueA = 5,
                ExpectedValueB = 8,
                ExpectedString = "без препятствия",
            };

            for (int i = 0; i < checker.Length; i++)
            {
                Console.WriteLine($"Box {checker[i].InputA} x {checker[i].InputB}\n[{checker[i].ExpectedString}]");
                Console.WriteLine();

                var board = new RectangularBox(checker[i].InputA, checker[i].InputB);
                var map = board.GetBoxWithObstacles(board, checker[i].InputC);
                board.PrintBox(map);

                Console.WriteLine();
                Console.WriteLine();
                Console.ReadKey();
            }

            Console.ReadKey();
        }
    }
}
