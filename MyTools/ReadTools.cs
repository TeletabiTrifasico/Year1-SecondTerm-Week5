namespace MyTools
{
    public class ReadTools
    {
        public static int ReadInt(string question)
        {
            Console.Write(question);
            int value = Convert.ToInt32(Console.ReadLine());
            return value;
        }
        public static int ReadInt(string question, int min, int max)
        {
            Console.Write(question);
            int value = Convert.ToInt32(Console.ReadLine());
            while (value < min || value > max)
            {
                Console.Write(question);
                value = Convert.ToInt32(Console.ReadLine());
            }
            return value;
        }
        public static string ReadString(string question)
        {
            Console.Write(question);
            string value = Console.ReadLine();
            return value;
        }
    }
}
