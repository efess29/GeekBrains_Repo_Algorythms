using System;

namespace Lesson4_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Source tree map:");
            var tree = new Node();
            tree.AddItem(30);
            tree.AddItem(25);
            tree.AddItem(41);
            tree.AddItem(20);
            tree.AddItem(27);
            tree.AddItem(50);
            tree.AddItem(35);
            tree.AddItem(61);
            tree.PrintMethodThree(tree);
            Console.ReadKey();
            Console.Clear();

            #region TEST 1

            // TEST 1
            Console.WriteLine("TEST 1 - Adding elements");
            
            var checker1 = new Checker[5];

            // На входе: 40, ожидание: элемент со значением 40 добавлен в правую часть
            checker1[0] = new Checker()
            {
                InputA = 40,
                ExpectedValue = 40
            };

            // На входе: 28, ожидание: элемент со значением 28 добавлен в правую часть
            checker1[1] = new Checker()
            {
                InputA = 28,
                ExpectedValue = 28
            };

            // На входе: 15, ожидание: элемент со значением 15 добавлен в левую часть
            checker1[2] = new Checker()
            {
                InputA = 15,
                ExpectedValue = 15
            };

            // На входе: 34, ожидание: элемент со значением 34 добавлен в левую часть
            checker1[3] = new Checker()
            {
                InputA = 34,
                ExpectedValue = 34
            };

            // На входе: 26, ожидание: элемент со значением 26 добавлен в левую часть
            checker1[4] = new Checker()
            {
                InputA = 26,
                ExpectedValue = 26
            };


            Console.WriteLine();
            Console.WriteLine("AddItem(40)");
            tree.AddItem(checker1[0].InputA);
            tree.PrintMethodThree(tree);
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("AddItem(28)");
            tree.AddItem(checker1[1].InputA);
            tree.PrintMethodThree(tree);
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("AddItem(15)");
            tree.AddItem(checker1[2].InputA);
            tree.PrintMethodThree(tree);
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("AddItem(34)");
            tree.AddItem(checker1[3].InputA);
            tree.PrintMethodThree(tree);
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("AddItem(26)");
            tree.AddItem(checker1[4].InputA);
            tree.PrintMethodThree(tree);
            Console.ReadKey();
            Console.Clear();

            #endregion

            #region TEST 2

            // TEST 2
            Console.WriteLine("TEST 2 - Searching by value");
            
            var checker2 = new Checker[4];
            
            checker2[0] = new Checker()
            {
                InputA = 35,
                ExpectedValue = 35,
            };

            checker2[1] = new Checker()
            {
                InputA = 27,
                ExpectedValue = 27,
            };

            checker2[2] = new Checker()
            {
                InputA = 30,
                ExpectedValue = 30,
            };

            checker2[3] = new Checker()
            {
                InputA = 41,
                ExpectedValue = 41,
            };

            for (int i = 0; i < checker2.Length; i++)
            {
                var res = tree.FindItem(checker2[i].InputA);
                Console.WriteLine($"InputA: {res.Data} ExpectedValue: {checker2[i].ExpectedValue}");
                Console.ReadKey();
            }

            Console.Clear();

            #endregion

            #region TEST 3

            // TEST 3
            Console.WriteLine("TEST 3 - Deleting by value");
            
            var checker3 = new Checker[3];

            checker3[0] = new Checker()
            {
                InputA = 50,
                ExpectedValue = 0,
            };

            checker3[1] = new Checker()
            {
                InputA = 25,
                ExpectedValue = 0,
            };

            checker3[2] = new Checker()
            {
                InputA = 30,
                ExpectedValue = 0,
            };

            Console.WriteLine("Map before delete:");
            Console.WriteLine();
            tree.PrintMethodThree(tree);

            for (int i = 0; i < checker3.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"RemoveItem({checker3[i].InputA})");
                Console.WriteLine();
                tree.RemoveValue(checker3[i].InputA);
                tree.PrintMethodThree(tree);
                Console.ReadKey();
            }

            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("Print tree 1st method");
            Console.WriteLine();
            tree.PrintMethodOne(tree);
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Print tree 2nd method");
            Console.WriteLine();
            tree.PrintMethodTwo(tree, 15);
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Print tree 3rd method");
            Console.WriteLine();
            tree.PrintMethodThree(tree);
            Console.ReadKey();
            Console.Clear();

            #endregion

            #region TEST 4

            //ТЕСТ - 4
            var checker4 = new Checker[4];

            checker4[0] = new Checker()
            {
                InputA = 5,
            };

            checker4[1] = new Checker()
            {
                InputA = 10,
            };

            checker4[2] = new Checker()
            {
                InputA = 15,
            };

            checker4[3] = new Checker()
            {
                InputA = 20,
            };

            Console.WriteLine("TEST 4 - Printing balanced tree");
            var newTree = new Node();
            for (int i = 0; i < checker4.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Tree contains {checker4[i].InputA} elements");
                newTree = Node.TreeAuto(checker4[i].InputA);
                newTree.PrintMethodThree(newTree);
                Console.ReadKey();
            }
            Console.ReadKey();

            #endregion

        }
    }
}
