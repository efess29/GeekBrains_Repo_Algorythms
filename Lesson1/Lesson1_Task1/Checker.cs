using System;

namespace Lesson1_Task1
{
    public class Checker
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Checker"/>
        /// </summary>
        public Checker()
        {
        }

        public const string Prime = "A prime number.";
        public const string NonPrime = "Not a prime number.";
        public const string Error = "Error: entered number is 0 or a negative number!";

        /// <summary>
        /// Получает или задает вводимое число
        /// </summary>
        public int Number { get; set; }
                
        /// <summary>
        /// Получает или задает ожидамое текстовое значение
        /// </summary>
        public string StringValue { get; set; }
    }
}
