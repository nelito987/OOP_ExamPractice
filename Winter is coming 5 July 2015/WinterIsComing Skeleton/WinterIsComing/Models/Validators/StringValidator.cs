using System;

namespace WinterIsComing.Models.Validators
{
    public static class StringValidator
    {
        public static void StringCheck(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentNullException("String cannot be null, empty or whitespace.");
            }
        }
    }
}
