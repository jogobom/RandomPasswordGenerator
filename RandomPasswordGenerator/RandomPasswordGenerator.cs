using System;
using System.Text;

namespace RandomPasswordGenerator
{
    public static class RandomPasswordGenerator
    {
        private static readonly Random RandomNumberGenerator = new();

        public static string GeneratePassword()
        {
            var passwordInProgress = new StringBuilder();

            const string letters = "abcdefghijklmnopqrstuvwxyz";
            for (var i = 0; i < 32; i++)
            {
                char randomLetter = '0';

                var typeOfCharacter = RandomNumberGenerator.Next(3);
                switch (typeOfCharacter)
                {
                    case 0:
                        randomLetter = GenerateRandomUpperOrLowercaseLetter(letters);
                        break;
                    case 1:
                        randomLetter = GenerateRandomNumericCharacter();
                        break;
                    case 2:
                        randomLetter = GenerateRandomSymbolCharacter();
                        break;
                }

                passwordInProgress.Append(randomLetter);
            }
            return passwordInProgress.ToString();
        }

        private static char GenerateRandomUpperOrLowercaseLetter(string letters)
        {
            var randomLetter = letters[RandomNumberGenerator.Next(letters.Length)];
            if (RandomNumberGenerator.Next(2) == 0)
            {
                randomLetter = char.ToUpper(randomLetter);
            }

            return randomLetter;
        }

        private static char GenerateRandomSymbolCharacter()
        {
            const string symbols = "#![]{}£$%&";
            return symbols[RandomNumberGenerator.Next(symbols.Length)];
        }

        private static char GenerateRandomNumericCharacter()
        {
            const string numeric = "1234567890";
            return numeric[RandomNumberGenerator.Next(numeric.Length)];
        }
    }
}
