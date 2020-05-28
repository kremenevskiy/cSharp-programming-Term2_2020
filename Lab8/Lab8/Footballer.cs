using System;

namespace Lab6
{
    public sealed class Footballer : Sportsman, IScorer
    {

        public bool IsScored()
        {
            Random scoreChance = new Random();
            int scoreCh = scoreChance.Next(0, 2500);
            if (ChanceToScore() >= scoreCh)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Hooray! Goooooooal!! Goooooal!!");
                Console.WriteLine($"{Name} {Surname} SCORED !!");
                Console.ResetColor();
                
                return true;
            }
            else if (ChanceToScore() + 100 >= scoreCh)
            {
                Console.WriteLine($"OMG!! It was so close!!\n" +
                                  $"{Name} {Surname} showing nice game\n" +
                                  $"but ball heated to the crossbar\n");
                return false;
            }
            else if (ChanceToScore() + 200 >= scoreCh)
            {
                Console.WriteLine($"Oooofff!! The ball hit the post!!\n" +
                                  $"{Name} {Surname} Good Try\n");
                return false;
            }
            else if (ChanceToScore() + 400 >= scoreCh)
            {
                Console.WriteLine($"Nice try! Accurate shot by {Name} {Surname} to the targer\n" +
                                  $"But goalkeeper caught the ball\n");
                return false;
            }
            else
                return false;
        }

        public int ChanceToScore()
        {
            Random gameLuck = new Random();

            return gameLuck.Next(0, 100) + Agility + Speed + Strength + Stamina;
        }

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


        public Footballer(string name, string surname, IFindCountry.Country country, GameStyle gameStyle,
            int agility, int stamina, int speed, int strength)
            : base(name, surname, country)
        {
            Style = gameStyle;
            
            _agility = agility;
            _stamina = stamina;
            _speed = speed;
            _strength = strength;
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