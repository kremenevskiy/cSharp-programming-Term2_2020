using System;
using System.Collections.Generic;
using System.Linq;


namespace Lab5
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
            
            people.Add(new Footballer("Cristiano", "Ronaldo",
                75, 187, Gender.Male, new DateTime(1985, 2, 5),
                Footballer.GameStyle.Striker));
            
            people.Add(new Boxer("Khabib", "Nurmagomedov",
                70, 178, Gender.Male, new DateTime(1988, 9, 20)));
            
            people.Add(new Runner("Usain", "Bolt",
                94, 195, Gender.Male, new DateTime(1986, 8, 21)));
            
            
            foreach (var man in people)
            {
                man.YearsPassed(5);
            }
            
            
            while (true)
            {
                ShowMenu();
                if(int.TryParse(Console.ReadLine(), out int choiсe) && (choiсe > 0 && choiсe < 12)){

                    switch (choiсe)
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
                            CastHuman();
                            break;
                        case 3:
                            ImproveSkills();
                            break;
                        case 4:
                            KillMan();
                            break;
                        case 5:
                            ViewFull();
                            break;
                        case 6:
                            ViewSportsmen();
                            break;
                        case 7:
                            SortByMoney();
                            break;
                        case 8:
                            SortByAge();
                            break;
                        case 9:
                            KillEveryone();
                            break;
                        case 10:
                            BoostTheTime();
                            break;
                        case 11:
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input!\n" +
                                  "Enter positive number: 0 < number < 13");
                }

                Console.Write("\nPress any key to continue...");
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

                string nameMan = name.Substring(0, spacePos);
                string surnameMan = name.Substring(++spacePos);
                
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



                Console.Write("\nMake him a Sportsmen?\n" +
                              "1. Yes. He will be new Football Star\n" +
                              "2. Yes. He will be Fast Runner\n" +
                              "3. Yes. He will be Strong Boxer\n" +
                              "4. No. He is simple human :(\n" +
                              "Enter: ");
                                  
                

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int choiсe) && (choiсe > 0 && choiсe < 5))
                    {
                        switch (choiсe)
                        {
                            case 1:
                                Footballer.GameStyle style = Footballer.GameStyle.Striker;
                                Console.Write("\nWhere is he playing?\n" +
                                              "1. Goalkeeper\n" +
                                              "2. Striker\n" +
                                              "3. Defender\n" +
                                              "4. Midfielder\n" +
                                              "Enter: ");
                                while (true)
                                {
                                    if (int.TryParse(Console.ReadLine(), out int choiсe2)
                                        && (choiсe2 > 0 && choiсe2 < 5))
                                    {
                                        switch (choiсe2)
                                        {
                                            case 1:
                                                style = Footballer.GameStyle.Goalkeeper;
                                                break;
                                            case 2:
                                                style = Footballer.GameStyle.Striker;
                                                break;
                                            case 3:
                                                style = Footballer.GameStyle.Defender;
                                                break;
                                            case 4:
                                                style = Footballer.GameStyle.Midfielder;
                                                break;
                                        }

                                        break;
                                    }
                                    else
                                    {
                                        Console.Write("Wrong number! 0 < number < 5\n" +
                                                          "Enter: ");
                                    }
                                }

                                Console.WriteLine("New Footballer - {0} is created successfully !\n" +
                                                  "Thank you God!\n", nameMan);
                                return new Footballer(nameMan, surnameMan, weight, height, gender, dateBirth, style);
                            case 2:
                                Console.WriteLine("New Runner - {0} is created successfully !\n" +
                                                  "Thank you God!\n", nameMan);
                                return new Runner(nameMan, surnameMan, weight, height, gender, dateBirth);
                            case 3:
                                Console.WriteLine("New Boxer - {0} is created successfully !\n" +
                                                  "Thank you God!\n", nameMan);
                                return new Boxer(nameMan, surnameMan, weight, height, gender, dateBirth);
                            case 4:
                                Console.WriteLine("New Human - {0} is created successfully !\n" +
                                                  "Thank you God!\n", nameMan);
                                return new Human(dateBirth, gender, height, weight, nameMan, surnameMan);
                        }
                    }
                    else
                    {
                        Console.Write("Wrong input!\n" +
                                          "Enter positive number: 0 < number < 5\n" +
                                          "Enter: ");
                    }
                }
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


        static int ShowNotSportByName()
        {
            int cnt = 0;
            foreach (var man in people)
            {
                if ((man as Sportsman) == null)
                {
                    Console.WriteLine($"{(cnt + 1).ToString()}. {man.Name} {man.Surname}");
                    cnt++;
                }
            }
            return cnt;
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
                if ((man as Sportsman) == null)
                {
                    Console.WriteLine("\n\tINFO");
                    man.ShowInfo();

                }
                else
                {
                    man.ShowInfo();
                }

            }
            Console.WriteLine();
        }

        
        static void ViewSportsmen()
        {
            int index = 0;
            foreach (var Man in people)
            {
                if ((Man as Sportsman) != null)
                {
                    Console.WriteLine($"{++index}. {Man.Name} {Man.Surname}");
                    if ((Man as Footballer) != null)
                    {
                        Console.WriteLine("Sport: Football");
                    }
                    else if ((Man as Boxer) != null)
                    {
                        Console.WriteLine("Sport: Boxing");
                    }
                    else if (((Man as Runner) != null))
                    {
                        Console.WriteLine("Sport: Boxing");
                    }
                    Man.SkillsInfo();
                    Console.WriteLine();
                }
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
            
            if (!int.TryParse(Console.ReadLine(), out choose) || choose < 1 || choose > people.Count + 1)
            {
                Console.WriteLine("Wrong input. Try again later!");
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
            Human.NumHumans = 0;
            Console.WriteLine("\nSuccessful ! Earth is Clear ! ");
        }


        static void CastHuman()
        {
            int cnt = ShowNotSportByName();

            Console.Write("Choose human to make Sportsman\n" +
                              "Enter: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) && (choice > 0 && choice <= cnt))
                {
                    int check = 0;
                    int index = 0;
                    foreach (var Man in people)
                    {
                        
                        if ((Man as Sportsman) == null)
                        {
                            check++;
                        }

                        if (check == choice)
                        {
                            Console.WriteLine($"Nice! Now {Man.Name} {Man.Surname} is Football player\n" +
                                              $"We need gather team to play!!!");
                            people[index] = new Footballer(Man.Name, Man.Surname, Man.Weight, Man.Weight,
                                Man.gender, Man.date_of_birth, Footballer.GameStyle.Midfielder);
                            return;
                        }

                        index++;
                    }
                }
                else
                {
                    Console.Write("Wrong number!\n" +
                                      "Enter: ");
                }
            }
            
        }

        static void ImproveSkills()
        {
            while (true)
            {
                int index = 0;

                foreach (var Man in people)
                {
                    Console.WriteLine($"{index + 1}. {Man.Name} {Man.Surname}");
                    Man.SkillsInfo();
                    Console.WriteLine();
                    index++;
                }

                while (true)
                {   Console.WriteLine("Which one improve?\n");
                    Console.Write("Enter: ");
                    if (int.TryParse(Console.ReadLine(), out int choise) &&
                        (choise > 0 && choise < Human.NumHumans + 1))
                    {
                        people[choise - 1].IncreaseSkills();
                        Console.WriteLine("All skills for {0} increased!", people[choise - 1].Name
                                                                           + people[choise - 1].Surname);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input!");
                    }

                }
                
                Console.Write("1. Continue train\n" +
                              "2. Leave train mode\n" +
                              "Enter: ");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int numTemp) && (numTemp == 1 || numTemp == 2))
                    {
                        switch (numTemp)
                        {
                            case 1:
                                break;
                            case 2:
                                return;
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input!\n" +
                                          "Enter: ");
                    }
                }
            }
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
            Console.WriteLine("There are {0} human beings on the Earth", Human.NumHumans.ToString());
            Console.WriteLine("1. Create human\n" +
                              "2. Make Sportsman from simple Human\n" +
                              "3. Improve people Skills\n" +
                              "4. Kill human\n" +
                              "5. __View all People__\n" +
                              "6. __View all Sportsmen__\n" +
                              "7. Sort by money\n" +
                              "8. Sort by age\n" +
                              "9. Kill everyone. Start again\n\n" +
                              "10. See what happens Few years later\n" +
                              "11. QUIT\n");
            Console.Write("Enter: ");
        }
    }
}