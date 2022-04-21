using System;

namespace Lesson2_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            list.AddNode(67);
            list.AddNode(88);
            list.AddNode(21);
            list.AddNode(45);
            list.AddNode(77);
            list.AddNode(90);
            list.AddNode(1);
            list.AddNode(12);
            list.AddNode(56);
            list.AddNode(777);

            var checker = new Checker[4];
            
            // На входе: 67, 1000, ожидание: 1000 --> 67
            checker[0] = new Checker()
            {
                InputA = 67,
                InputB = 1000,
                ExpectedValue = 1000,
            };

            // На входе: 45, 1000, ожидание: 45 --> 1000
            checker[1] = new Checker()
            {
                InputA = 45,
                InputB = 1000,
                ExpectedValue = 1000,
            };

            // На входе: 90, 1000, ожидание: 90 --> 1000
            checker[2] = new Checker()
            {
                InputA = 90,
                InputB = 1000,
                ExpectedValue = 1000,
            };

            // На входе: 777, 1000, ожидание: 777 --> 1000
            checker[3] = new Checker()
            {
                InputA = 777,
                InputB = 1000,
                ExpectedValue = 1000,
            };

            // ========== TEST 1 ========== //

            list.AddNodeAfter(list.FindNode(checker[0].InputA), checker[0].InputB);
            list.AddNodeAfter(list.FindNode(checker[1].InputA), checker[1].InputB);
            list.AddNodeAfter(list.FindNode(checker[2].InputA), checker[2].InputB);
            list.AddNodeAfter(list.FindNode(checker[3].InputA), checker[3].InputB);

            Console.WriteLine("TEST 1");

            list.PrintList();

            Console.ReadKey();

            // ========== TEST 2 ========== //

            var checker2 = new Checker[3];
            
            // На входе: 45, ожидание: удалится (число 45) 21 --> 1000
            checker2[0] = new Checker()
            {
                InputA = 45
            };

            // На входе: индекс 7 (77), ожидание: удалится (число 77) 90 --> 1000
            checker2[1] = new Checker()
            {
                InputA = 7
            };

            list.RemoveNode(list.FindNode(checker2[0].InputA));
            list.RemoveNode(checker2[1].InputA);
            
            Console.WriteLine("TEST 2");
            
            list.PrintList();

            Console.ReadKey();
        }
    }
}
