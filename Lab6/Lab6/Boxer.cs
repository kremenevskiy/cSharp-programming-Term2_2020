using System;
using Lab6;

namespace Lab6
{
    public class Boxer : Sportsman, IFighter<Boxer>
    {

        public float Hit()
        {
            float damage;
            float coefficient = FightCoefficient;

            damage = Strength * 0.1f + Stamina * 0.1f + Agility * 0.1f;
            
            return damage;
        }

        public bool FightAgainst(Boxer opponent)
        {
            int luck1 = randLuck();
            int luck2 = randLuck();
            
            Console.WriteLine("\n____Battle started!____");
            Console.WriteLine("Boxer vs Boxer\n");
            Console.WriteLine($"{this.Name} {this.Surname} vs {opponent.Name} {opponent.Surname}");
            Console.WriteLine("Calculating chances...");
            Console.WriteLine("{0, -16}| {1, -13} % {2, -10}",
                $"Boxer: {this.Name}", $"Round Luck: {luck1.ToString()}", $"| Damage: {this.Hit().ToString()}");
            Console.WriteLine("{0, -16}| {1, -13} % {2, -10}",
                $"Boxer: {opponent.Name}", $"Round Luck: {luck2.ToString()}", $"| Damage: {opponent.Hit().ToString()}");

            float winChance1 = this.Hit() + ( luck1 * 0.05f );
            float winChance2 = opponent.Hit() + ( luck2 * 0.05f );
            
            if (winChance1 > winChance2) 
                Console.WriteLine("\nWinner : {0}", $"{this.Name} {this.Surname} | Country: {this.CountryFrom}\n");
            else
                Console.WriteLine("\nWinner : {0}", $"{opponent.Name} {opponent.Surname} | Country:" +
                                                    $" {opponent.CountryFrom}\n\n");
            
            
            return winChance1 > winChance2;
        }

        public float FightCoefficient { get; set; } = 3;
        
        public Boxer(string name, string surname, IFindCountry.Country country, int agility, int stamina, int speed, int strength)
            : base(name, surname, country)
        {
            _agility = agility;
            _stamina = stamina;
            _speed = speed;
            _strength = strength;
        }


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