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
            Random r = new Random();
            int rInt = r.Next(0, words.Length);
            string word = words[rInt];
            string underscoreWord = ConvertWord(word);
            Console.WriteLine($"Paraula: {underscoreWord}");
            
            char char1 = GetChar(1);
            char char2 = GetChar(2);
            char char3 = GetChar(3);
            
            string newWord = CheckWord(word, char1, char2, char3);
            Console.WriteLine($"Paraula: {newWord}");
            
            int lives = 3;
            while (lives > 0)
            {
                Console.WriteLine("Quina és la paraula?");
                string wordGuess = Console.ReadLine() ?? "";
                while (!CheckValidity(wordGuess))
                {
                    Console.WriteLine("El que has introduit conté números.");
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
                    Console.WriteLine($"Tens {lives} vides.");
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
            char[] wordChar = word.ToCharArray();
            string newWord = "";
            foreach (var character in wordChar)
            {
                newWord += "_ ";
            }

            return newWord;
        }
        
        static string CheckWord(string word, char char1, char char2, char char3)
        {
            char[] wordChar = word.ToCharArray();
            string newWord = "";
            foreach (var character in wordChar)
            {
                if (character == char1 || character == char2 || character == char3)
                {
                    newWord += character + " ";
                }
                else
                {
                    newWord += "_" + " ";
                }
            }

            return newWord;
        }

        static char GetChar(int index)
        {
            char char1 = ' ';
            while (true)
            {
                if (index == 1)
                {
                    Console.WriteLine("Introdueix la primera lletra: ");
                }
                else if (index == 2)
                {
                    Console.WriteLine("Introdueix la segona lletra: ");
                }
                else if (index == 3)
                {
                    Console.WriteLine("Introdueix la tercera lletra: ");
                }
                else
                {
                    Console.WriteLine("Introdueix la lletra: ");
                }
                string input = Console.ReadLine() ?? "";
                if (input.Length > 1)
                {
                    Console.WriteLine("Només pots introduir una lletra.");
                }
                else if (!CheckValidity(input))
                {
                    Console.WriteLine("El que has introduit conté números.");
                }
                else
                {
                    char1 = char.TryParse(input, out char1) ? char1 : ' ';
                    if (char1 == ' ')
                    {
                        Console.WriteLine("El que has introduit no és una lletra.");
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return char1;
        }

        static bool CheckValidity(string word)
        {
            foreach (var letter in word)
            {
                if (int.TryParse(letter.ToString(), out int number))
                {
                    return false;
                }
            }

            return true;
        }
    }
}