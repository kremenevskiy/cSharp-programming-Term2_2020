using System;

namespace Lab5
{
    public class Runner : Sportsman
    {
        public Runner(string name, string surname, int weight, int height, Gender gender,
            DateTime dateOfBirth) : base(name, surname, dateOfBirth, gender, weight, height)
        {
            Random rand = new Random();
            _speed = rand.Next(70, 80);
            _stamina = rand.Next(70, 80);
            _agility = rand.Next(40, 50);
            _strength = rand.Next(10, 20);
        }
        
        public override int Speed
        {
            get => _speed;
            set
            {
                if (value <= 100)
                    _speed = value;
            }
        }

        public override int Stamina
        {
            get => _stamina;
            set
            {
                if (value <= 90)
                    _stamina = value;
            }
        }

        public override int Agility
        {
            get => _agility;
            set
            {
                if (value <= 80)
                    _agility = value;
            }
        }

        public override int Strength
        {
            get => _strength;
            set
            {
                if (value <= 50)
                    _strength = value;
            }
        }
        
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.Write("Sport doing : ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Running");
            Console.ResetColor();
        }
        
    }
}