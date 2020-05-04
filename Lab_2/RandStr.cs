using System;
using System.Text;

namespace Lab_2
{
    public class RandStr
    {
        public static void Execute()
        {
            Console.WriteLine("\nTask: Сгенерировать равновероятно случайную строку " +
                              "длиной не более четырех строчных английских букв.");

            Random rand = new Random();
            var myString = new StringBuilder();

            do
            {
                for (int i = 0; i < rand.Next(1, 5); i++)
                {
                    var ch = (char) rand.Next(97, 123);
                    myString.Append(ch);
                }
                
                Console.WriteLine("\n\nGenerated string: {0}\n", myString);
                myString.Clear();
                
                Console.Write("Press Q -- Quit\n" +
                              "Any other key -- Continue\n" +
                              "Key Pressed: ");
            } while (Console.ReadKey().Key != ConsoleKey.Q);
        }
    }
}