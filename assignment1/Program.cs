using MyTools;

namespace assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }
        void Start()
        {
            int value = ReadTools.ReadInt("Enter a value: ");
            Console.WriteLine("You entered {0}.", value);

            int age = ReadTools.ReadInt("How old are you? ", 0, 120);
            Console.WriteLine("You are {0} years old.", age);

            string name = ReadTools.ReadString("What is your name? ");
            Console.WriteLine("Nice meeting you {0}.", name);

            Console.ReadKey();
        }
    }
}