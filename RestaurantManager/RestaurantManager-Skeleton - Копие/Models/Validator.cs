using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public static class Validator
    {
        public static void CheckIfStringIsNullOrEmpty(string text, string message = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new NullReferenceException(message);
            }
        }

        public static void CheckIfPositive(int value, string message = null)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }
        public static void CheckIfPositive(decimal value, string message = null)
        {
            if (value <= 0)
            {
                throw new ArgumentException(message);
            }
        }

        
    }
}
