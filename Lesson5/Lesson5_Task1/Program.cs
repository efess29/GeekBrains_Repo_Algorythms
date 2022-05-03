using System;

namespace Lesson5_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Node();
            tree.AddItem(30);
            tree.AddItem(25);
            tree.AddItem(41);
            tree.AddItem(20);
            tree.AddItem(27);
            tree.AddItem(50);
            tree.AddItem(35);
            tree.AddItem(61);
            tree.AddItem(40);
            tree.AddItem(28);
            tree.AddItem(15);
            tree.AddItem(34);
            tree.AddItem(26);
            tree.PrintMethodThree(tree);

            var checker = new Checker[5];
            checker[0] = new Checker()
            {
                InputA = 25,
                ExpectedValue = 25,
            };
            
            checker[1] = new Checker()
            {
                InputA = 28,
                ExpectedValue = 28,
            };
            
            checker[2] = new Checker()
            {
                InputA = 40,
                ExpectedValue = 40,
            };
            
            checker[3] = new Checker()
            {
                InputA = 61,
                ExpectedValue = 61,
            };
            
            checker[4] = new Checker()
            {
                InputA = 30,
                ExpectedValue = 30,
            };

            Console.WriteLine();
            Console.WriteLine("Search: DFS");
            
            for (int i = 0; i < checker.Length; i++)
            {
                var dfs = tree.DFSsearch(tree, checker[i].InputA);
                
                for (int j = 0; j < dfs.Length; j++)
                {
                    Console.WriteLine($"Values: [{dfs[j].Node.Data}] Search depth: [{dfs[j].Depth}]");
                    Console.ReadKey();
                }
            }

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Search: BFS");
            
            tree.PrintMethodThree(tree);
            
            for (int i = 0; i < checker.Length; i++)
            {
                var bfs = tree.BFSsearch(tree, checker[i].InputA);
                
                for (int j = 0; j < bfs.Length; j++)
                {
                    Console.WriteLine($"Values: [{bfs[j].Node.Data}] Search depth: [{bfs[j].Depth}]");
                    Console.ReadKey();
                }
            }


            Console.WriteLine("Search ended.");
            Console.ReadKey();
        }
    }
}
