using System;

namespace Lesson4_Task1
{
    public class StringGenerator
    {
        private char GenerateChars(Random rnd)
        {
            return (char)(rnd.Next('A', 'Z' + 1));
        }

        public string GenerateStrings(Random rnd, int length)
        {
            char[] letters = new char[length];
            
            for (int i = 0; i < length; i++)
            {
                letters[i] = GenerateChars(rnd);
            }

            return new string(letters);
        }
    }
}
