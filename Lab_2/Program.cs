using System;
using System.Numerics;
using System.Text;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            
            do
            {
                Console.Write("\n\nPress \"1\" -- First Task (Generating Random String)\n" +
                              "Press \"2\" -- Second Task (Search biggest Degree of 2 | (a * (a+1)...(b-1) * b)\n" +
                              "Press \"3\" -- Third Task (Working with current DateTime in different Formats)\n" +
                              "Press \"esc\" -- End the Session\n" +
                              "Pressed: ");

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    RandStr.Execute();
                }
                else if (key.Key == ConsoleKey.D2)
                {    
                    Console.Clear();
                    Degree2.Execute();
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    Console.Clear();
                    Date.Execute();
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("\t Escape");
                    return;
                }
                
                else
                {
                    Console.Write("\n\nINCORRECT INPUT!!\n" +
                                      "Press any key to Continue");
                    Console.ReadKey(true);
                }

            } while (true);
            
        }
    }
}