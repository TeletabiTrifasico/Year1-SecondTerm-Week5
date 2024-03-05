namespace assignment3
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
            Dictionary<string, string> words = new Dictionary<string, string>();
            words = ReadWords(filename);
            Console.Write("Enter a word: ");
            TranslateWords(words);
        }
        Dictionary<string, string> ReadWords(string filename)
        {
            Dictionary<string, string> words = new Dictionary<string, string>();
            StreamReader reader = new StreamReader(filename);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] lineWords = line.Split(';');
                string dutchWord = lineWords[0];
                string englishWord = lineWords[1];
                words.Add(dutchWord, englishWord);
            }
            reader.Close();
            return words;
        }
        void TranslateWords(Dictionary<string, string> words)
        {
            string dutchWord;
            do
            {
                dutchWord = Console.ReadLine();
                if (words.ContainsKey(dutchWord))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{dutchWord} => {words[dutchWord]}");
                    Console.ResetColor();
                }
                else if (dutchWord == "listall")
                {
                    ListAllWords(words);
                }
                else if (dutchWord != "stop")
                {
                    Console.WriteLine($"word '{dutchWord}' not found");
                }
            } 
            while (dutchWord != "stop");
        }
        void ListAllWords(Dictionary<string, string> words)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (KeyValuePair<string, string> values in words)
            {
                Console.WriteLine($"{values.Key} => {values.Value}");
            }
            Console.ResetColor();
        }
    }
}