using System;
using System.Security.Cryptography;
using System.Text;

using System.Collections.Generic;

namespace Lab3
{
    public class Human
    {
        public string Name { get; private set; } 
        public string Surname { get; private set; }
        public static int NumHumans;
        public string PassportID { get; private set; }
        public int Luck { get; private set; }
        public int Expeience { get; set; } 
        public int Money { get; set; } 
        public int Age { get; private set; }
        public Gender gender;
        public int Height { get; set; }
        public int Weight { get; set; }
        public DateTime date_of_birth;

        public Human()
        {
            ++NumHumans;
            PassportID = CreateID();
            Luck = randLuck();
            Money = 1;
            Expeience = 1;
            

            Name = "Alien";
            Surname = "Al";
            date_of_birth = DateTime.Now;
            Height = 50;
            Weight = 5;
        }

        
        public Human(string Name, string Surname) : this()
        {
            this.Name = Name;
            this.Surname = Surname;
        }

        
        public Human(int Height, int Weight, string Name, string Surname) : this(Name, Surname)
        {
            this.Height = Height;
            this.Weight = Weight;
        }

        
        public Human(DateTime DateOfBirth, Gender gender, int Height, int Weight, string Name, string Surname) : 
            this(Height, Weight, Name, Surname)
        {
            date_of_birth = DateOfBirth;
            this.gender = gender;
            CalculateAge();
        }


        public void CalculateAge()
        {
            Age = DateTime.Now.Year - date_of_birth.Year;
        }


        public static string CreateID()
        {
            Random rand = new Random();
            char temp = (char) rand.Next(65, 91);

            StringBuilder passport = new StringBuilder();
            passport.Append(temp);
            
            temp = (char) rand.Next(65, 91);
            passport.Append(temp);

            int tempNum = rand.Next(2000000, 3000000);
            passport.Append(tempNum.ToString());

            return passport.ToString();
        }


        public static int randLuck()
        {
            int luck;
            Random rand = new Random();
            int chance = rand.Next(1, 5);
            if (chance == 4)
            {
                luck = rand.Next(1, 25) * 4;
            }
            else
            {
                luck = rand.Next(1, 25);
            }
            return luck;
        }


        public static void ShowPopulation()
        {
            Console.WriteLine($"There are {NumHumans.ToString()} human beings on the Earth");
        }

        
        public void YearsPassed(int years)
        {
            for (int i = 0; i < years; i++)
            {
                Age++;
                Expeience++;
                Money += Expeience * 10 * Luck;
                
            }
        }


        public void ShowInfo()
        {
            Console.WriteLine("INFO");
            Console.WriteLine($"Passport ID -- {PassportID}\n" +
                              $"Name -- {Name}\n" +
                              $"Surname -- {Surname}\n" +
                              $"Gender -- {gender}\n" +
                              $"DateBirth -- {date_of_birth.ToString("yyyy MMMM dd")}\n" +
                              $"Age -- {Age.ToString()} y.o\n" +
                              $"Weight -- {Weight.ToString()} kg\n" +
                              $"Height -- {Height.ToString()} cm\n\n" +
                              $"Experience -- {Expeience.ToString()} \n" +
                              $"Luck -- {Luck.ToString()}%\n" +
                              $"Money -- {Money.ToString()}$\n");
        }
    }
    
    
    public class CompareByAge : IComparer<Human>
    {
        public int Compare(Human x, Human y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }


    public class CompareByMoney : IComparer<Human>
    {
        public int Compare(Human one, Human two)
        {
            return one.Money.CompareTo(two.Money);
        }
    }

    
    public enum Gender
    {
        Male,
        Female
    }
}