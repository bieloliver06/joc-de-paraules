using System.Text;

namespace jocdeparaules
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(@"
             _       ______  ____  ____     ________  __________________
            | |     / / __ \/ __ \/ __ \   / ____/ / / / ____/ ___/ ___/
            | | /| / / / / / /_/ / / / /  / / __/ / / / __/  \__ \\__ \ 
            | |/ |/ / /_/ / _, _/ /_/ /  / /_/ / /_/ / /___ ___/ /__/ / 
            |__/|__/\____/_/ |_/_____/   \____/\____/_____//____/____/ 
            ");
                        
            string[] words = System.IO.File.ReadAllLines("words.txt");
            string word = words[new Random().Next(0, words.Length)];
            string underscoreWord = ConvertWord(word);
            Console.WriteLine($"Paraula: {underscoreWord}");
            
            char char1 = GetChar(1);
            char char2 = GetChar(2);
            char char3 = GetChar(3);
            
            string newWord = CheckWord(word, char1, char2, char3);

            int lives = 3;
            while (lives > 0)
            {
                Console.WriteLine($"Tens {lives} vides.");
                Console.WriteLine($"Paraula: {newWord}");
                Console.WriteLine("Quina és la paraula?");
                string wordGuess = Console.ReadLine() ?? "";
                while (wordGuess.Any(char.IsDigit))
                {
                    Console.WriteLine("El que has introduit conté números.");
                    Console.WriteLine($"Paraula: {newWord}");
                    Console.WriteLine("Quina és la paraula?");
                    wordGuess = Console.ReadLine() ?? "";
                }
                if (wordGuess == word)
                {
                    Console.WriteLine("Has guanyat!");
                    break;
                }
                else if (wordGuess == "")
                {
                    Console.WriteLine("El que has introduit no és una paraula.");
                }
                else
                {
                    lives--;
                }
            }
            if (lives == 0)
            {
                Console.WriteLine("Has perdut!");
                Console.WriteLine($"La paraula era: {word}");
            }

        }

        static string ConvertWord(string word)
        {
            StringBuilder newWord = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
            {
                newWord.Append("_ ");
            }

            return newWord.ToString();
        }
        
        static string CheckWord(string word, char char1, char char2, char char3)
        {
            StringBuilder newWord = new StringBuilder();
            foreach (var character in word)
            {
                if (character == char1 || character == char2 || character == char3)
                {
                    newWord.Append(character).Append(" ");
                }
                else
                {
                    newWord.Append("_ ");
                }
            }

            return newWord.ToString();
        }

        static char GetChar(int index)
        {
            char letter;
            while (true)
            {
                Console.Write($"Introdueix la {(index == 1 ? "primera" : index == 2 ? "segona" : index == 3 ? "tercera" : "")} lletra: ");
                string input = Console.ReadLine() ?? "";
                if (input.Length != 1 || input.Any(char.IsDigit) || !char.TryParse(input.ToLower(), out letter) )
                {
                    Console.WriteLine("El que has introduit no és una lletra.");
                }
                else
                {
                    return letter;
                }
            }
        }
    }
}