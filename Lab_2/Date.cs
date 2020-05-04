using System;

namespace Lab_2
{
    public class Date
    {
        public static void Execute()
        {
            DateTime dateTimeNow = DateTime.Now;

            Console.WriteLine($"\nTimeNow: {dateTimeNow.ToString()}");

            Console.WriteLine("Task: Получить текущее время и дату в двух разных форматах и вывести на экран" +
                              " количество нулей, единиц, …, девяток в их записи.\n\n");
            
            

            string[] timeFormat = dateTimeNow.GetDateTimeFormats();
            string timeFormat1 = timeFormat[3];
            string timeFormat2 = timeFormat[13];
            
            Console.WriteLine($"First Format: {timeFormat[3]}");
            Console.WriteLine($"Second Format: {timeFormat[13]}\n");

            String overallString = timeFormat1 + timeFormat2;

            for (int i = 48; i < 58; i++)
            {
                int cnt = 0;
                foreach (var ch in overallString)
                {
                    if (ch == i)
                    {
                        cnt++;
                    }
                }
                
                Console.WriteLine("Amount of \"{0}\" in both Formats: {1}", (i - 48).ToString(), cnt);
            }
            
            Console.WriteLine("\n\nPress any Key to Continue");
            Console.ReadKey(true);
        }
    }
}