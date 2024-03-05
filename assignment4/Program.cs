using MyTools;

namespace assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("invalid number of arguments!");
                Console.WriteLine("usage: assignment[3-4] <filename>");
                return;
            }
            string filename = args[0];
            Program myProgram = new Program();
            myProgram.Start(filename);
        }
        void Start(string filename)
        {
            LingoGame lingoGame = new LingoGame();
            List<string> words = ReadWords(filename, 5);

            string lingoWord = SelectWord(words);
            lingoGame.Init(lingoWord);

            if (PlayLingo(lingoGame))
            {
                Console.WriteLine("You have guessed the word!");
            }
            else
            {
                Console.WriteLine($"Too bad, you did not guess the word ({lingoWord})");
            }
        }
        List<string> ReadWords(string filename, int wordLength)
        {
            List<string> words = new List<string>();
            StreamReader reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                string word = reader.ReadLine();
                if (word.Length == wordLength)
                {
                    words.Add(word);
                }
            }
            reader.Close();
            return words;
        }
        string SelectWord(List<string> words)
        {
            Random random = new Random();
            return words[random.Next(0, words.Count)];
        }

        string ReadPlayerWord(int wordLength, int attemptsLeft)
        {
            string word;
            do
            {
                word = ReadTools.ReadString($"Enter a ({wordLength}-letter) word, attempts left {attemptsLeft}: ");
            } 
            while (wordLength != word.Length);
            word = word.ToUpper();
            return word;
        }
        void DisplayPlayerWord(string playerWord, LetterState[] letterResults)
        {
            for (int i = 0; i < playerWord.Length; i++)
            {
                if (letterResults[i] == LetterState.Correct)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }
                else if (letterResults[i] == LetterState.WrongPosition)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }
                Console.Write(playerWord[i]);
                Console.ResetColor();
            }
            Console.WriteLine("");
        }

        bool PlayLingo(LingoGame lingoGame)
        {
            int attemptsLeft = 5;
            int wordLength = lingoGame.lingoWord.Length;
            string playerWord;

            while (attemptsLeft > 0 && !lingoGame.WordGuessed())
            {
                playerWord = ReadPlayerWord(wordLength, attemptsLeft);
                LetterState[] letterResults = lingoGame.ProcessWord(playerWord);
                DisplayPlayerWord(playerWord, letterResults);
                attemptsLeft--;
            }
            return lingoGame.WordGuessed();
        }
    }
}
