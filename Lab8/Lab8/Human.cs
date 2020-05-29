using System;
using System.Security.Cryptography;
using System.Text;

using System.Collections.Generic;

namespace Lab8
{
    public class Human : IFindCountry
    {
        public void SelectCountry(IFindCountry.Country country)
        {
            CountryFrom = country.ToString();
        }

        public IFindCountry.Country Country;
        
        public string CountryFrom { get; set; }
        
        public string Name { get; protected set; } 
        public string Surname { get; protected set; }
        public static int NumHumans;
        public string PassportID { get; private set; }
        public int Luck { get; private set; }
        public int Experience { get; set; } 
        public int Money { get; set; } 
        public int Age { get;  set; }
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
            Experience = 1;

            Name = "Alien";
            Surname = "Al";
            date_of_birth = DateTime.Now;
            Height = 50;
            Weight = 5;
        }

        public Human(IFindCountry.Country country) : this()
        {
            this.Country = country;
            SelectCountry(country);
        }
        
        protected string Hello { get; }

        
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

        
        public virtual void YearsPassed(int years)
        {
            for (int i = 0; i < years; i++)
            {
                Age++;
                Experience++;
                Money += Experience * 10 * Luck;
                
            }
        }


        public virtual void SkillsInfo()
        {
            Console.WriteLine("{0, -11}: {1, -5}", "Experience", Experience.ToString());
        }

        public virtual void IncreaseSkills()
        {
            Experience++;
        }
        
        
        public virtual void ShowInfo()
        {
            Console.WriteLine("{0, -12}: {1, -15}", "Name", Name);
            Console.WriteLine("{0, -12}: {1, -15}", "Surname", Surname);
            Console.WriteLine("{0, -12}: {1, -15}", "Passport ID", PassportID);
            Console.WriteLine("{0, -12}: {1, -15}", "Gender", gender.ToString());
            Console.WriteLine("{0, -12}: {1, -15}", "DateBirth", date_of_birth.ToString("yyyy MMMM dd"));
            Console.WriteLine("{0, -12}: {1, -15}", "Age", Age.ToString() + " y.o");
            Console.WriteLine("{0, -12}: {1, -15}", "Weight", Weight.ToString() + " kg");
            Console.WriteLine("{0, -12}: {1, -15}", "Height", Height.ToString() + " cm");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0, -12}: {1, -15}", "Experience", Experience.ToString());
            Console.WriteLine("{0, -12}: {1, -15}", "Luck", Luck.ToString() + " %");
            Console.WriteLine("{0, -12}: {1, -15}", "Money", Money.ToString() + " $");
            Console.ResetColor();
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