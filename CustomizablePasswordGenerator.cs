using System;
using System.Text;

namespace CustomizablePasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter minimum length of password:");
            int minimumLength = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter maximum length of password:");
            int maximumLength = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter required number of digits in password:");
            int numberOfDigits = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter required number of special characters in password:");
            int numberOfSpecialChars = Int32.Parse(Console.ReadLine());

            PasswordGenerator.ValidateInput(minimumLength, maximumLength, numberOfDigits, numberOfSpecialChars);

            string password = PasswordGenerator.GeneratePassword(minimumLength, maximumLength, numberOfDigits, numberOfSpecialChars);

            Console.WriteLine("Generated Password is: " + password);
            Console.WriteLine("Length is: " + password.Length);
        }
    }
    class PasswordGenerator
    {
        public static void ValidateInput(int minLength, int maxLength, int numberOfDigits, int numberOfSpecialChars)
        {
            if (maxLength < minLength)
                throw new Exception("Minimum length cannot be bigger than max length!");

            if (numberOfDigits + numberOfSpecialChars > maxLength)
                throw new Exception("Sum of digit and symbol numbers cannot be bigger than max length");

        }

        public static String GeneratePassword(int minLength, int maxLength, int numberOfDigits, int numberOfSpecialChars)
        {
            char[] numbers = "0123456789".ToCharArray();
            char[] symbols = "^$?!@#%&".ToCharArray();
            char[] allAllowed = "abcdefghijklmnopqrstuvwxyzABCDEFGJKLMNPRSTUVWXYZ0123456789^$?!@#%&".ToCharArray();

            Random random = new Random();
            StringBuilder password = new StringBuilder();
            for (int i = 0; i < numberOfDigits; i++)
            {
                password.Insert(random.Next(password.Length + 1),numbers[random.Next(numbers.Length)]);
            }
            for (int i = 0; i < numberOfSpecialChars; i++)
            {
                password.Insert(random.Next(password.Length + 1),symbols[random.Next(symbols.Length)]);
            }
            int randomLength = maxLength;
            if (maxLength - minLength > 0)
            {
                randomLength = random.Next(maxLength - minLength + 1) + minLength;
            }
            int remainingLength = randomLength - numberOfDigits - numberOfSpecialChars;
            for (int i = 0; i < remainingLength; i++)
            {
                password.Insert(random.Next(password.Length + 1),allAllowed[random.Next(allAllowed.Length)]);
            }

            return password.ToString();

        }

    }
}
