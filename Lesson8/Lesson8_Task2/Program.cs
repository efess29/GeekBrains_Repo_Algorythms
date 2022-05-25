using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson8_Task2
{
    class Program
    {
        private static void SplitBigFile(string file)
        {
            int splitNumber = 1;
            
            StreamWriter writer = new StreamWriter(string.Format(@"C:\ExternalArray\tmp\split{0:d5}.txt", splitNumber));
            
            using (StreamReader reader = new StreamReader(file))
            {
                while (reader.Peek() >= 0)
                {
                    writer.WriteLine(reader.ReadLine());
            
                    if (writer.BaseStream.Length > 100000000 && reader.Peek() >= 0)
                    {
                        writer.Close();
                        splitNumber++;
                        writer = new StreamWriter(string.Format(@"C:\ExternalArray\tmp\split{0:d5}.txt", splitNumber));
                    }
                }
            }
            
            writer.Close();
        }

        private static void SortParts(string tempFiles)
        {
            foreach (string path in Directory.GetFiles(tempFiles, "split*.txt"))
            {
                string[] content = File.ReadAllLines(path);
                int[] arrayOfNum = new int[content.Length];

                for (int i = 0; i < content.Length; i++)
                {
                    var cont = Convert.ToInt32(content[i]);

                    if (cont != 0)
                    {
                        arrayOfNum[i] = cont;
                    }
                }

                MergeSort(arrayOfNum);

                for (int i = 0; i < arrayOfNum.Length; i++)
                {
                    content[i] = Convert.ToString(arrayOfNum[i]);
                }

                string newPath = path.Replace("split", "sorted");
                File.WriteAllLines(newPath, content);
                File.Delete(path);

                content = null;
                arrayOfNum = null;

                GC.Collect();
            }
        }

        private static void MergeFiles(string sortedFile, string tempFiles)
        {
            string[] paths = Directory.GetFiles(tempFiles, "sorted*.txt");
            int blocks = paths.Length;
            int recordSize = 100;
            int maxUsage = 500000000;
            int bufferSize = maxUsage / blocks;
            double recordOverHead = 7.5;
            int bufferLength = (int)(bufferSize / recordSize / recordOverHead);

            StreamReader[] readers = new StreamReader[blocks];
            for (int i = 0; i < blocks; i++)
            {
                readers[i] = new StreamReader(paths[i]);
            }

            Queue<string>[] queues = new Queue<string>[blocks];
            
            for (int i = 0; i < blocks; i++)
            {
                queues[i] = new Queue<string>(bufferLength);
            }

            for (int i = 0; i < blocks; i++)
            {
                LoadQueue(queues[i], readers[i], bufferLength);
            }

            StreamWriter writer = new StreamWriter(sortedFile);
            bool isDone = false;
            int lowIndex;
            string lowValue;

            while (!isDone)
            {
                lowIndex = -1;
                lowValue = "";

                for (int j = 0; j < blocks; j++)
                {
                    if (queues[j] != null)
                    {
                        if (lowIndex < 0 || String.CompareOrdinal(queues[j].Peek(), lowValue) < 0)
                        {
                            lowIndex = j;
                            lowValue = queues[j].Peek();
                        }
                    }
                }

                if (lowIndex == -1)
                {
                    isDone = true;
                    break;
                }

                writer.WriteLine(lowValue);
                queues[lowIndex].Dequeue();

                if (queues[lowIndex].Count == 0)
                {
                    LoadQueue(queues[lowIndex], readers[lowIndex], bufferLength);

                    if (queues[lowIndex].Count == 0)
                    {
                        queues[lowIndex] = null;
                    }
                }
            }

            writer.Close();

            for (int i = 0; i < blocks; i++)
            {
                readers[i].Close();
                File.Delete(paths[i]);
            }
        }

        private static void LoadQueue(Queue<string> queue, StreamReader file, int bufferLength)
        {
            for (int i = 0; i < bufferLength; i++)
            {
                if (file.Peek() < 0)
                {
                    break;
                }

                queue.Enqueue(file.ReadLine());
            }
        }

        private static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1]; var index = 0;
            
            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }

                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }

        private static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                if (highIndex - lowIndex == 1)
                {
                    if (array[highIndex] < array[lowIndex])
                    {
                        var t = array[lowIndex]; array[lowIndex] = array[highIndex]; array[highIndex] = t;
                    }
                }

                else
                {
                    var middleIndex = (lowIndex + highIndex) / 2;
                    MergeSort(array, lowIndex, middleIndex);
                    MergeSort(array, middleIndex + 1, highIndex);
                    Merge(array, lowIndex, middleIndex, highIndex);
                }
            }

            return array;
        }

        private static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }

        public static void ExternalSort(string readBigFile, string tempFiles, string sortedFile)
        {
            SplitBigFile(readBigFile);

            Console.WriteLine("Split process is done!");
            Console.WriteLine();

            SortParts(tempFiles);

            Console.WriteLine("SortFilesIsDone");
            Console.WriteLine();

            MergeFiles(sortedFile, tempFiles);

            Console.WriteLine("ProcessIsDone");
        }

        static void Main(string[] args)
        {
            var checker = new Checker[4];

            checker[0] = new Checker()
            {
                InputA = 1000,
                ExpectedValueA = 1000,
                ExpectedValueB = "Sorted file with 1000 items",
            };

            checker[1] = new Checker()
            {
                InputA = 5000,
                ExpectedValueA = 5000,
                ExpectedValueB = "Sorted file with 5000 items",
            };

            checker[2] = new Checker()
            {
                InputA = 9000,
                ExpectedValueA = 9000,
                ExpectedValueB = "Sorted file with 9000 items",
            };

            checker[3] = new Checker()
            {
                InputA = 15000,
                ExpectedValueA = 15000,
                ExpectedValueB = "Sorted file with 15000 items",
            };

            for (int i = 0; i < checker.Length; i++)
            {
                var readBigFile = $@"C:\ExternalArray\UnsortedArray({checker[i].InputA}).txt";
                var tempFiles = @"C:\ExternalArray\tmp";
                var sortedFile = $@"C:\ExternalArray\SortedArray\SortedArray({checker[i].ExpectedValueA}).txt";

                ExternalSort(readBigFile, tempFiles, sortedFile);
            }

            Console.ReadKey();
        }
    }
}
