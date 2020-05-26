using System;

namespace Lab5
{
    public class Boxer : Sportsman
    {
        public Boxer(string name, string surname, int weight, int height, Gender gender,
            DateTime dateOfBirth) : base(name, surname, dateOfBirth, gender, weight, height)
        {
            Random rand = new Random();

            _strength = rand.Next(70, 80);
            _stamina = rand.Next(60, 70);
            _agility = rand.Next(20, 30);
            _speed = rand.Next(5, 15);
        }

        
        public override int Speed
        {
            get => _speed;           
            set
            {
                if (value <= 50)
                    _speed = value;
            }
        }

        public override int Stamina
        {
            get => _stamina;
            set
            {
                if (value <= 80)
                    _stamina = value;
            }
        }

        public override int Agility
        {
            get => _agility;
            set
            {
                if (value <= 50)
                    _agility = value;
            }
        }

        public override int Strength
        {
            get => _strength;
            set
            {
                if (value <= 100)
                    _strength = value;
            }
        }
        
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.Write("Sport doing : ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Boxing");
            Console.ResetColor();
            
        }

    }
}