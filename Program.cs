 namespace jocdeparaules
{
    class Program
    {
        static void Main()
        {
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
            while (char1 == ' ')
            {
                if (index == 1)
                {
                    Console.WriteLine("Introdueix la primera lletra: ");
                    char1 = char.TryParse(Console.ReadLine(), out char1) ? char1 : ' ';
                }
                else if (index == 2)
                {
                    Console.WriteLine("Introdueix la segona lletra: ");
                    char1 = char.TryParse(Console.ReadLine(), out char1) ? char1 : ' ';
                }
                else if (index == 3)
                {
                    Console.WriteLine("Introdueix la tercera lletra: ");
                    char1 = char.TryParse(Console.ReadLine(), out char1) ? char1 : ' ';
                }
                else
                {
                    Console.WriteLine("Introdueix la lletra: ");
                    char1 = char.TryParse(Console.ReadLine(), out char1) ? char1 : ' ';
                }
            }

            return char1;
        }
    }
}