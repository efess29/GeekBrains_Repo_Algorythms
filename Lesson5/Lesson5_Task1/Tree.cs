using System;
using System.Collections.Generic;

namespace Lesson5_Task1
{
    public class Node
    {
        private enum Side
        {
            Left,
            Right
        }

        public class NodeInfo
        {
            public Node Node { get; set; }
            
            public string Text;
            
            public int StartPos;
            
            public int Size { get { return Text.Length; } }
            
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            
            public NodeInfo Parent, Left, Right;
            
            public int Depth { get; set; }
        }

        public int Data { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public Node Parent { get; set; }

        public Node RootNode { get; set; }

        public static Node TreeAuto(int numberOfElements)
        {
            Node newNode = null;

            if (numberOfElements == 0)
            {
                return null;
            }

            else
            {
                var nodeLeft = numberOfElements / 2;
                var nodeRight = numberOfElements - nodeLeft - 1;
                newNode = new Node();
                newNode.Data = new Random().Next(1000);
                newNode.Left = TreeAuto(nodeLeft);
                newNode.Right = TreeAuto(nodeRight);
                newNode.RootNode = newNode;
            }

            return newNode;
        }

        /// <summary>
        /// Представляет метод BFS-поиска в ширину
        /// </summary>
        /// <param name="node"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public NodeInfo[] BFSsearch(Node node, int searchValue)
        {
            var bufer = new Queue<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo() { Node = node.RootNode };
            bufer.Enqueue(root);
            
            if (bufer == null)
            {
                return null;
            }

            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                
                if (element.Node.Data == searchValue)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Searchable element: {element.Node.Data}");
                    
                    return returnArray.ToArray();
                }

                else
                {
                    returnArray.Add(element);
                    var depth = element.Depth + 1;

                    if (element.Node.Left != null)
                    {
                        var left = new NodeInfo()
                        {
                            Node = element.Node.Left,
                            Depth = depth,
                        };

                        bufer.Enqueue(left);
                    }

                    if (element.Node.Right != null)
                    {
                        var left = new NodeInfo()
                        {
                            Node = element.Node.Right,
                            Depth = depth,
                        };

                        bufer.Enqueue(left);
                    }
                }
            }

            return returnArray.ToArray();
        }

        /// <summary>
        /// Представляет метод DFS-поиска в глубину
        /// </summary>
        /// <param name="node"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public NodeInfo[] DFSsearch(Node node, int searchValue)
        {
            var bufer = new Stack<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo() { Node = node.RootNode };
            bufer.Push(root);
            
            if (bufer == null)
            {
                return null;
            }

            while (bufer.Count != 0)
            {
                var element = bufer.Pop();
                
                if (element.Node.Data == searchValue)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Searchable element: {element.Node.Data}");
                    
                    return returnArray.ToArray();
                }

                returnArray.Add(element);
                var depth = element.Depth + 1;

                if (element.Node.Right != null)
                {
                    var right = new NodeInfo()
                    {
                        Node = element.Node.Right,
                        Depth = depth,
                    };

                    bufer.Push(right);
                }

                if (element.Node.Left != null)
                {
                    var left = new NodeInfo()
                    {
                        Node = element.Node.Left,
                        Depth = depth,
                    };

                    bufer.Push(left);
                }
            }

            return returnArray.ToArray();
        }

        public void AddItem(int value)
        {
            if (Data == 0 || Data == value)
            {
                Data = value;

                return;
            }

            if (Data > value)
            {
                if (Left == null)
                {
                    Left = new Node();
                }

                AddItem(value, Left, this);
            }

            else
            {
                if (Right == null)
                {
                    Right = new Node();
                }

                AddItem(value, Right, this);
            }
        }

        private void AddItem(int value, Node node, Node parent)
        {
            if (node.Data == 0 || node.Data == value)
            {
                node.Data = value;
                node.Parent = parent;
                
                if (RootNode == null)
                {
                    node.Parent.RootNode = parent;
                }

                return;
            }

            if (node.Data > value)
            {
                if (node.Left == null)
                {
                    node.Left = new Node();
                }

                AddItem(value, node.Left, node);
            }

            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node();
                }

                AddItem(value, node.Right, node);
            }
        }

        private void AddItem(Node value, Node node, Node parent)
        {

            if (node.Data == 0 || node.Data == value.Data)
            {
                node.Data = value.Data;
                node.Left = value.Left;
                node.Right = value.Right;
                node.Parent = parent;
                
                return;
            }

            if (node.Data > value.Data)
            {
                if (node.Left == null)
                {
                    node.Left = new Node();
                }

                AddItem(value, node.Left, node);
            }

            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node();
                }

                AddItem(value, node.Right, node);
            }
        }

        public Node FindItem(int value)
        {
            if (Data == value)
            {
                return this;
            }

            if (Data > value)
            {
                return FindItem(value, Left);
            }

            return FindItem(value, Right);
        }

        private Node FindItem(int value, Node node)
        {
            if (node == null)
            {
                Console.WriteLine("Value not find!");
                
                return null;
            }

            if (node.Data == value)
            {
                return node;
            }

            if (node.Data > value)
            {
                return FindItem(value, node.Left);
            }

            return FindItem(value, node.Right);
        }

        private void RemoveNode(Node node)
        {
            if (node == null)
            {
                return;
            }
            var curNodeForParent = CurNodeForParent(node);

            if (node.Left == null && node.Right == null)
            {
                if (curNodeForParent == Side.Left)
                {
                    node.Parent.Left = null;
                }

                else
                {
                    node.Parent.Right = null;
                }

                return;
            }

            if (node.Left == null)
            {
                if (curNodeForParent == Side.Left)
                {
                    node.Parent.Left = node.Right;
                }

                else
                {
                    node.Parent.Right = node.Right;
                }

                node.Right.Parent = node.Parent;
                
                return;
            }

            if (node.Right == null)
            {
                if (curNodeForParent == Side.Left)
                {
                    node.Parent.Left = node.Left;
                }

                else
                {
                    node.Parent.Right = node.Left;
                }

                node.Left.Parent = node.Parent;
                
                return;
            }

            if (curNodeForParent == Side.Left)
            {
                node.Parent.Left = node.Right;
            }

            if (curNodeForParent == Side.Right)
            {
                node.Parent.Right = node.Right;
            }

            if (curNodeForParent == null)
            {
                var bufLeft = node.Left;
                var bufRightLeft = node.Right.Left;
                var bufRightRight = node.Right.Right;
                node.Data = node.Right.Data;
                node.Right = bufRightRight;
                node.Left = bufRightLeft;
                AddItem(bufLeft, node, node);
            }

            else
            {
                node.Right.Parent = node.Parent;
                AddItem(node.Left, node.Right, node.Right);
            }
        }

        public void RemoveValue(int value)
        {
            var removeNode = FindItem(value);
            
            if (removeNode != null)
            {
                RemoveNode(removeNode);
            }
        }

        private Side? CurNodeForParent(Node node)
        {
            if (node.Parent == null)
            {
                return null;
            }

            if (node.Parent.Left == node)
            {
                return Side.Left;
            }

            if (node.Parent.Right == node)
            {
                return Side.Right;
            }

            return null;
        }

        public void PrintMethodOne(Node node)
        {
            DisplayTree(node.RootNode);
        }

        private void DisplayTree(Node node, string indent = "", Side? side = null)
        {
            if (node != null)
            {
                var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{indent} [{nodeSide}] - [{node.Data}]");
                
                indent += new string(' ', 3);

                DisplayTree(node.Left, indent, Side.Left);
                DisplayTree(node.Right, indent, Side.Right);
            }
        }

        public void PrintMethodTwo(Node node, int padding)
        {
            if (node != null)
            {
                if (node.Right != null)
                {
                    PrintMethodTwo(node.Right, padding + 4);
                }

                if (padding > 0)
                {
                    Console.Write(" ".PadLeft(padding));
                }

                if (node.Right != null)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("/\n");
                    Console.Write(" ".PadLeft(padding));
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(node.Data.ToString() + "\n ");
                
                if (node.Left != null)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(" ".PadLeft(padding) + "\\\n");
                    PrintMethodTwo(node.Left, padding + 4);
                }
            }
        }

        public void PrintMethodThree(Node node, string textFormat = "[ 0 ]", int spacing = 1, int topMargin = 2, int leftMargin = 2)
        {
            if (node == null)
            {
                return;
            }

            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = node.RootNode;
            
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo { Node = next, Text = next.Data.ToString(textFormat) };
                
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + spacing;
                    last[level] = item;
                }

                else
                {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }

                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.Left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos - 1);
                    }

                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos + 1);
                    }
                }

                next = next.Left ?? next.Right;
                
                for (; next == null; item = item.Parent)
                {
                    int top = rootTop + 2 * level;
                    Console.ForegroundColor = ConsoleColor.White;
                    PrintMethodThree(item.Text, top, item.StartPos);
                    
                    if (item.Left != null)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        PrintMethodThree("/", top + 1, item.Left.EndPos);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        PrintMethodThree("_", top, item.Left.EndPos + 1, item.StartPos);
                    }

                    if (item.Right != null)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        PrintMethodThree("_", top, item.EndPos, item.Right.StartPos - 1);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        PrintMethodThree("\\", top + 1, item.Right.StartPos - 1);
                    }

                    if (--level < 0)
                    {
                        break;
                    }

                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos + 1;
                        next = item.Parent.Node.Right;
                    }
                    
                    else
                    {
                        if (item.Parent.Left == null)
                        {
                            item.Parent.EndPos = item.StartPos - 1;
                        }

                        else
                        {
                            item.Parent.StartPos += (item.StartPos - 1 - item.Parent.EndPos) / 2;
                        }
                    }
                }
            }

            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        private static void PrintMethodThree(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            
            if (right < 0)
            {
                right = left + s.Length;
            }

            while (Console.CursorLeft < right)
            {
                Console.Write(s);
            }
        }
    }
}
