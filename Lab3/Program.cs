using System;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Transactions;

namespace Lab3
{
    class Program
    {
        static List<Human> people = new List<Human>();
        static DateTime time = DateTime.Now;
        
        static void Main(string[] args)
        {
            DateTime timeStarted = DateTime.Now;

            people.Add(new Human(new DateTime(1971, 6, 28), Gender.Male,
                183, 84, "Elon", "Musk"));
            
            people.Add(new Human(new DateTime(2000, 1, 20), Gender.Female,
                168, 62, "Kristinka", "Gromova"));
            
            people.Add(new Human(new DateTime(2002, 5, 1), Gender.Female,
                170, 60, "Polinka", "Efimova"));
            
            people.Add(new Human(new DateTime(1984, 10, 10), Gender.Male,
                175, 79, "Pasha", "Durov"));
            
            foreach (var man in people)
            {
                man.YearsPassed(12);
            }
            
            
            while (true)
            {
                ShowMenu();
                int i = Console.Read() - 48;
                Console.Read();
                
                switch (i)
                {
                    case 1:
                        Human man = CreateHuman();
                        if (man == null)
                        {
                            Console.WriteLine("Man isn't created. Something go wrong (");
                            continue;
                        }
                        people.Add(man);
                        break;
                    case 2:
                        KillMan();
                        break;
                    case 3:
                        ViewFull();
                        break;
                    case 4:
                        SortByMoney();
                        break;
                    case 5:
                        SortByAge();
                        break;
                    case 6:
                        KillEveryone();
                        break;
                    case 7:
                        BoostTheTime();
                        break;
                    case 8:
                        return;
                    default:
                        Console.Write("Wrong input, try again!\n\n");
                        
                        break;
                }

                Console.Write("Press any key to continue...");
                Console.ReadKey(true);

            }
        }

        static Human CreateHuman()
        {
            string name;
            Console.Write("Enter Name and Surname through space: ");

            int spacePos;
            try
            {
                name = Console.ReadLine();
                spacePos = name.IndexOf(' ');
                
                if (spacePos == -1)
                {
                    throw new Exception("Type space between Name and Surname");
                }

                
                Console.Write("Write Date of Birth (3 nums through spaces: MM dd yyyy)\n" +
                              "Enter: ");
                
                string[] date = Console.ReadLine().Split(' ');

                if (date.Length != 3)
                {
                    throw new Exception("Enter just 3 numbers through space!");
                }
                
                DateTime dateBirth = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]),
                    Convert.ToInt32(date[0]));

                
                Console.Write("Enter height(cm) and weight(kg) (2 numbers through spaces)\n" +
                                  "Enter: ");
                int[] date2 = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

                int height = date2[0];
                int weight = date2[1];


                Console.Write("What is gender? Male - 1, Female - 2\nEnter: ");
                Gender gender;
                int i = Console.Read() - 48;
                if (i == 1)
                {
                    gender = Gender.Male;
                }
                else if (i == 2)
                {
                    gender = Gender.Female;
                }
                else
                {
                    throw new Exception("Write only 1(Male) ot 2(Female)!");
                }

                
                Console.WriteLine("Man was created successfully. Thank you GOD!");
                Console.Read();

                return new Human(dateBirth, gender, height, weight, name.Substring(0, spacePos),
                    name.Substring(++spacePos));
            }
            
            
            catch (Exception ex)
            {
                
                Console.WriteLine("\nWrong input !\n" +
                                  "Try again later :(");
                Console.WriteLine($"Tip: {ex.Message}");
                
                Console.Write("Press any key to continue...");
                Console.ReadKey(true);
                
                return null;
            }
            
        }
        
        
        static void ShowByName()
        {
            int i = 0;
            foreach (var man in people)
            {
                Console.WriteLine($"{(i + 1).ToString()}. {man.Name} {man.Surname}");
                i++;
            }
        }
        
        
        static void ViewFull()
        {
            if (people.Count == 0)
            {
                Console.WriteLine("Ooops, no humans on the Earth. Create some");
                return;
            }
            
            foreach (var man in people)
            {
                man.ShowInfo();
                
            }
        }


        static void KillMan()
        {
            if (people.Count == 0)
            {
                Console.WriteLine("Ooops, no humans on the Earth. Create some");
                return;
            }
            
            ShowByName();
            Console.Write("Who do you want to kill?\nEnter: ");
            int choose;
            
            if (!int.TryParse(Console.ReadLine(), out choose) || choose < 1 || choose > people.Count)
            {
                Console.WriteLine("Wrong input. Try again!");
                return;
            }

            choose--;

            Console.WriteLine($"{people[choose].Name} {people[choose].Surname} has been killed !!");
            people.RemoveAt(choose);
        }


        static void SortByAge()
        {
            people.Sort(new CompareByAge());
            Console.WriteLine("Successful ! People are sorted by Age !");

        }


        static void SortByMoney()
        {
            people.Sort(new CompareByMoney());
            Console.WriteLine("\nSuccessful ! People are sorted by Money !");
        }


        static void KillEveryone()
        {
            people.Clear();
            Console.WriteLine("\nSuccessful ! Earth is Clear ! ");
        }


        static void BoostTheTime()
        {
            
            Console.Write("How many years to move to the future? \n0 < time < 100\nEnter Time: ");
            if (!int.TryParse(Console.ReadLine(), out int time) || time < 1 || time > 100)
            {
                Console.WriteLine("Wrong input! Try again");
                return;
            }
            
            foreach (var man in people)
            {
                man.YearsPassed(time);
            }

            Program.time = Program.time.AddYears(time);
            
            Console.WriteLine("\n{0} years have been passed!\n" +
                              "View everyone now!\n" +
                              "Date now: {1}\n" +
                              "Look how Earth has been changed!\n", time.ToString(),
                                Program.time.ToString("yyyy MMMM dd"));
            
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n\nDate now: {0}", time.ToString("yyyy MMMM dd"));
            Console.WriteLine("1. Create human\n" +
                              "2. Kill human\n" +
                              "3. __View people__\n" +
                              "4. Sort by money\n" +
                              "5. Sort by age\n" +
                              "6. Kill everyone. Start again\n\n" +
                              "7. See what happens Few years later\n" +
                              "8. QUIT\n");
            Console.Write("Enter: ");
        }
    }
}