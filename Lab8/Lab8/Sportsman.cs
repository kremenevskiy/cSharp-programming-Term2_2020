using System;

namespace Lab8
{
    public abstract class Sportsman : Human
    {
        

        protected int _speed;
        protected int _agility;
        protected int _strength;      
        protected int _stamina;

        public int Health { get; set; } = 50;

        public abstract int Speed { get; set; }

        public abstract int Stamina { get; set; }

        public abstract int Agility { get; set; }

        public abstract int Strength { get; set; }

        public int TimeInSport { get; set; }

        public Sportsman(string name, string surname, DateTime dateOfBirth, Gender gender,
            int weight, int height) : base(dateOfBirth, gender, height, weight, name, surname)
        {
            
        }

        public Sportsman(string name, string surname, IFindCountry.Country country) : base(country)
        {
            Name = name;
            Surname = surname;
        }


        protected Sportsman(int yearsInSport)
        {
            TimeInSport = yearsInSport;
        }
        
        
        public override void YearsPassed(int years)
        {
            double ratio = (_agility + _speed + _strength + _stamina) / 100.0;
            for (int i = 0; i < years; i++)
            {
                Age++;
                Experience += (int) ratio;
                Money += Experience * 10 * Luck;
            }
            Money = (int)(Money * ratio);
        }

        public override void ShowInfo()
        {
            Console.WriteLine("\n\tINFO");
            if (gender == Gender.Male)
                Console.WriteLine("___OMG! He is Sportsmen!___");
            else
                Console.WriteLine("___OMG! She is Sportsmen!___");
            
            base.ShowInfo();
        }

        public override void SkillsInfo()
        {
            base.SkillsInfo();
            Console.WriteLine("{0, -11}: {1, -5}", "Speed", _speed.ToString());
            Console.WriteLine("{0, -11}: {1, -5}", "Strength", _strength.ToString());
            Console.WriteLine("{0, -11}: {1, -5}", "Stamina", _stamina.ToString());
            Console.WriteLine("{0, -11}: {1, -5}", "Agility", _agility.ToString());
        }

        public override void IncreaseSkills()
        {
            base.IncreaseSkills();
            _speed++;
            _stamina++;
            _agility++;
            _strength++;
        }
    }
}