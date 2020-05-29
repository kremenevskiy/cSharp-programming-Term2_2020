using System;

namespace Lab8
{
    public class Runner : Sportsman, IRunner
    {
        public float Speed100M { get; set; }
        public float Speed1Km { get; set; }
        public float Speed10Km { get; set; }
        public static float DistanceRun { get; set; } = 1000;
        public float PersonTime { get; private set; }
        private bool _raceStarted = true;

        public float Run(float distance)
        {
            Speed100M = Speed * 0.1f;
            Speed1Km = Speed * 0.1f * Stamina * 0.01f;
            Speed10Km = Speed * 0.1f * Stamina * 0.007f;

            float speed;
            
            if (_raceStarted)
                Console.WriteLine($"{this.Name} {this.Surname} running - {distance.ToString()} meters");
            
            if (distance <= 100)
                speed = Speed100M;
            else if (distance <= 1000)
                speed = Speed1Km;
            else
                speed = Speed10Km;

            float time = distance / speed;
            if (_raceStarted)
                Console.WriteLine($"Time: {time.ToString()} seconds");
            
            if (time < IRunner.Record)
            {
                if (_raceStarted)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Omg!! It's new Record!! Nice job");
                    Console.ResetColor();
                }

                IRunner.Record = time;
            }

            if (_raceStarted)
            {
                Console.WriteLine("\nPress any key to start next Race!");
                Console.ReadKey(true);
                PersonTime = time;
                _raceStarted = false;
            }
            
            return time;
        }

        public int CompareTo(IRunner other)
        {
            return this.Run(DistanceRun).CompareTo(other.Run(DistanceRun));
        }

        public Runner(string name, string surname, IFindCountry.Country country,
            int agility, int stamina, int speed, int strength)
            : base(name, surname, country)
        {
            _agility = agility;
            _stamina = stamina;
            _speed = speed;
            _strength = strength;
        }
        

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