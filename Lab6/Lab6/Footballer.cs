using System;

namespace Lab5
{
    public sealed class Footballer : Sportsman
    {
        public enum GameStyle
        {
            Goalkeeper,
            Striker,
            Defender,
            Midfielder
        }

        public GameStyle Style;
        
        public Footballer(string name, string surname, int weight, int height, Gender gender,
            DateTime dateOfBirth, GameStyle gameStyle) : base(name, surname, dateOfBirth, gender, weight, height)
        {
            Random rand = new Random();
            _agility = rand.Next(80, 90);
            _stamina = rand.Next(70, 80);
            _speed = rand.Next(60, 70);
            _strength = rand.Next(20, 30);
            Style = gameStyle;
        }
        
        public override int Agility
        {
            get => _agility;
            set
            {
                if (value <= 100)
                    _agility = value;
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

        public override int Speed
        {
            get => _speed;
            set
            {
                if (value < 90)
                    _speed = value;
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
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Football");
            Console.ResetColor();
        }
    }
}