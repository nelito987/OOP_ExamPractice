
using System;

namespace MusicShop.Models
{
    public class Validator
    {
        public static void CheckIfStringIsNullOrEmpty(string text, string message = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new NullReferenceException(message);
            }
        }

        public static void CheckIfPositive(decimal number, string message = null)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }

        public static void CheckIfNegative(decimal number, string message = null)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }

    }
}
