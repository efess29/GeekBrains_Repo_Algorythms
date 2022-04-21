using System;

namespace Lesson2_Task1
{
    /// <summary>
    /// Представляет класс двусвязного списка
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Получает или задает значение элемента
        /// </summary>
        public int Value { get; set; }
        
        /// <summary>
        /// Получает или задает следующий элемент
        /// </summary>
        public Node NextItem { get; set; }

        /// <summary>
        /// Получает или задает предыдущий элемент
        /// </summary>
        public Node PrevItem { get; set; }
    }

    /// <summary>
    /// Представляет класс реализации интерфейса <see cref="ILinkedList"/>
    /// </summary>
    public class LinkedList : ILinkedList
    {
        private Node _startNode; 
        private Node _endNode;
        private int count;

        /// <summary>
        /// Реализует метод добавления элемента
        /// </summary>
        /// <param name="value"></param>
        public void AddNode(int value)
        {
            var newNode = new Node { Value = value };


            if (_startNode == null)
            {
                _startNode = newNode;
            }

            else
            {
                _endNode.NextItem = newNode;
                newNode.PrevItem = _endNode;
            }

            _endNode = newNode;
            count++;
        }

        /// <summary>
        /// Реализует метод добавления элемента после определенного элемента
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        public void AddNodeAfter(Node node, int value)
        {
            Node currentNode = _startNode;
            Node previousNode = null;
            var newNode = new Node { Value = value };

            while (currentNode != null)
            {
                if (currentNode == node)
                {
                    if (previousNode != null)
                    {
                        var nodeNext = currentNode.NextItem;
                        currentNode.NextItem = newNode;

                        node.NextItem = newNode;
                        newNode.NextItem = nodeNext;
                        newNode.PrevItem = currentNode;

                        if (currentNode.NextItem.NextItem == null)
                        {
                            _endNode = newNode;
                        }

                        else
                        {
                            nodeNext.PrevItem = newNode;
                        }
                    }

                    else
                    {
                        newNode.NextItem = _startNode;
                        _startNode = newNode;

                        if (_startNode == null)
                        {
                            _endNode = null;
                        }

                        else
                        {
                            currentNode.PrevItem = newNode;
                        }
                    }

                    count++;
                    return;
                }

                previousNode = currentNode;
                currentNode = currentNode.NextItem;
            }
        }

        /// <summary>
        /// Реализует метод поиска элемента по значению
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public Node FindNode(int searchValue)
        {
            var currentNode = _startNode;

            while (currentNode != null)
            {
                if (currentNode.Value == searchValue)
                {
                    return currentNode;
                }

                currentNode = currentNode.NextItem;
            }

            return null;
        }

        public int GetCount()
        {
            return count;
        }

        /// <summary>
        /// Реализует метод удаления элемента по индексу
        /// </summary>
        /// <param name="index"></param>
        public void RemoveNode(int index)
        {
            Node currentNode = _startNode;
            Node previousNode = null;
            int _index = 0;

            while (currentNode != null)
            {
                _index++;

                if (_index == index - 1)
                {
                    if (previousNode != null)
                    {
                        previousNode.NextItem = currentNode.NextItem;

                        if (currentNode.NextItem == null)
                        {
                            _endNode = previousNode;
                        }

                        else
                        {
                            currentNode.NextItem.PrevItem = previousNode;
                        }
                    }

                    else
                    {
                        _startNode = _startNode.NextItem;
                        _startNode.PrevItem = null;

                        if (_startNode == null)
                        {
                            _endNode = null;
                        }
                    }

                    count--;
                    return;
                }

                previousNode = currentNode;
                currentNode = currentNode.NextItem;
            }
        }

        /// <summary>
        /// Реализует метод удаления определенного элемента
        /// </summary>
        /// <param name="node"></param>
        public void RemoveNode(Node node)
        {
            Node currentNode = _startNode;
            Node previousNode = null;

            while (currentNode != null)
            {
                if (currentNode == node)
                {
                    if (previousNode != null)
                    {
                        previousNode.NextItem = currentNode.NextItem;

                        if (currentNode.NextItem == null)
                        {
                            _endNode = previousNode;
                        }

                        else
                        {
                            currentNode.NextItem.PrevItem = previousNode;
                        }
                    }

                    else
                    {
                        _startNode = _startNode.NextItem;
                        _startNode.PrevItem = null;

                        if (_startNode == null)
                        {
                            _endNode = null;
                        }
                    }

                    count--;
                    return;
                }

                previousNode = currentNode;
                currentNode = currentNode.NextItem;
            }
        }

        /// <summary>
        /// Представляет метод вывода элементов
        /// </summary>
        public void PrintList()
        {
            int index = 0;
            var currentNode = _startNode;
            while (currentNode != null)
            {
                index++;

                if (currentNode.PrevItem == null)
                {
                    Console.WriteLine("null <- [PrevItem]");
                }

                Console.WriteLine($"<- [PrevItem] [index] {index} [{currentNode.Value}] [NextItem] -> ");
                
                if (currentNode.NextItem == null)
                {
                    Console.WriteLine("[NextItem] -> null");
                }

                currentNode = currentNode.NextItem;
            }

            Console.WriteLine();
            Console.WriteLine($"Total elements amount: {GetCount()}");
        }
    }


    public interface ILinkedList
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int GetCount();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        void AddNode(int value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        void AddNodeAfter(Node node, int value);

        /// <summary>
        /// Представляет
        /// </summary>
        /// <param name="index"></param>
        void RemoveNode(int index);

        /// <summary>
        /// Представляет метод удаления конкретного элемента
        /// </summary>
        /// <param name="node"></param>
        void RemoveNode(Node node);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        Node FindNode(int searchValue);
    }
}
