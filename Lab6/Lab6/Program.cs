using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace Lab6
{
    class Program
    {
        static List<Human> players = new List<Human>();

        static string[] CountriesList =
        {
            "Belarus", "Russia", "Spain", /*"Portugal", "USA",
            "France", "Canada", "Jamaica"*/
        };
        
        static int pointsBelarus;
        static int pointsRussia;
        static int pointsSpain;
        static int pointsPortugal;
        static int pointsUSA;
        static int pointsFrance;
        static int pointsCanada;
        static int pointsJamaica;

        static void Main(string[] args)
        {
            InitializePlayers();
            
            Console.WriteLine("\n___Welcome to WORLD CUP!___\n");
            Console.WriteLine("Today Events:\n" +
                              "1. Running Race\n" +
                              "2. Fight Battles\n" +
                              "3. Football games");

            Console.WriteLine("Press any key to continue...\n");
            Console.ReadKey(true);
            
            StartRunningRace(players.Where(human => human is IRunner)
                .Select(human => human as IRunner).ToList());
            
            ShowCountryPoints();
            Console.WriteLine("Press any key to continue...\n");
            Console.ReadKey(true);
            
            StartFightBattles(players.Where(human => human is IFighter<Boxer>)
                 .Select(human => human as IFighter<Boxer>).ToList());
            
            ShowCountryPoints();
            Console.WriteLine("Press any key to continue...\n");
            Console.ReadKey(true);
             
            StartFootballGames(players.Where(human => human is IScorer)
                 .Select(human => human as IScorer).ToList());
            
            
            ShowCountryPoints();
            
            Console.WriteLine("Thanks for watching! See you next time!");
        }

        static void StartRunningRace(List<IRunner> runners)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("___Race Starting!___");
            Console.ResetColor();
            Runner.DistanceRun = 3000;
            runners.Sort();

            Console.WriteLine("\nLeaderBoard:");
            int index = 0;
            foreach (var runner in runners)
            {
                Console.WriteLine($"{index++ + 1}. {runner.Name} {runner.Surname}\n\tCountry: {runner.CountryFrom}" +
                                  $" | Time: {runner.PersonTime.ToString()}");
                
                AddPoints(runner.CountryFrom, runners.Count - index + 1);

            }
        }

        static void StartFightBattles(List<IFighter<Boxer>> boxers)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("___Boxing Starting!___\n");
            Console.ResetColor();
            Console.WriteLine("Boxers:");
            foreach (var boxer in boxers)
            {
                Console.WriteLine("{0, -20} | {1, -10}", $"{boxer.Name} {boxer.Surname}",
                    $"Country: {boxer.CountryFrom}");
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey(true);
            Random rand = new Random();
            foreach (var boxer in boxers)
            {
                bool win = true;
                bool played = true;

                while (played)
                {
                    Boxer opponent = boxers[rand.Next(0, boxers.Count)] as Boxer;

                    if (boxer.CountryFrom == opponent.CountryFrom)
                    {
                        continue;
                    }
                    else{

                        win = boxer.FightAgainst(opponent);
                        played = false;
                        
                        if (win)
                            AddPoints(boxer.CountryFrom, 1);
                        else
                            AddPoints(opponent.CountryFrom, 1);
                    }
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
            }
        }

        static void StartFootballGames(List<IScorer> footballers)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("___Football Time!___\n");
            Console.ResetColor();
            foreach (var country in CountriesList)
            {
                
                Console.WriteLine($"\n{country} players:");
                
                foreach (var footPlayer in footballers)
                {
                    if (footPlayer.CountryFrom == country)
                    {
                        Console.WriteLine($"\t{footPlayer.Name} {footPlayer.Surname}");
                    }
                }
                Console.WriteLine("\nPress any key to Continue");
                Console.ReadKey(true);
                
            }

            foreach (var country in CountriesList)
            {
                Console.WriteLine($"{country} is playing now!\n");
                
                foreach (var footPlayer in footballers)
                {
                    if (footPlayer.CountryFrom == country)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (footPlayer.IsScored())
                            {
                                AddPoints(country, 1);
                                Console.WriteLine("\nPress any key to Continue\n");
                                Console.ReadKey(true);
                            }
                        }
                    }
                }
                Console.WriteLine($"\t{country} Played all games\n\n" +
                                  $"Press any Key to Continue");
                Console.ReadKey(true);
            }

            Console.WriteLine("Football ended! All teams showed good work!");
        }

        static void InitializePlayers()
        {
            // Football players
            players.Add(new Footballer("Cristiano", "Ronaldo", IFindCountry.Country.Belarus,
                Footballer.GameStyle.Striker, 100, 80, 100, 40));

            players.Add(new Footballer("Lionel", "Messi", IFindCountry.Country.Spain,
                Footballer.GameStyle.Striker, 100, 85, 95, 20));
            players.Add(new Footballer("Vladislav", "Kremenevskiy", IFindCountry.Country.Belarus,
                Footballer.GameStyle.Striker, 70, 50, 80, 30));
            players.Add(new Footballer("Igor", "Akinfeev", IFindCountry.Country.Russia,
                Footballer.GameStyle.Goalkeeper, 50, 60, 60, 40));
            players.Add(new Footballer("Andrei", "Arshavin", IFindCountry.Country.Russia,
                Footballer.GameStyle.Midfielder, 70, 70, 70, 30));
            players.Add(new Footballer("Andres", "Iniesta", IFindCountry.Country.Spain,
                Footballer.GameStyle.Midfielder, 80, 80, 80, 40));

            // Runners
            players.Add(new Runner("Usain", "Bolt", IFindCountry.Country.Spain,
                70, 90, 100, 30));
            players.Add(new Runner("Tyreek", "Hill", IFindCountry.Country.Belarus,
                75, 90, 95, 30));
            players.Add(new Runner("Danila", "Berezshnov", IFindCountry.Country.Belarus,
                50, 60, 50, 20));
            players.Add(new Runner("Nikolay", "Sobolev", IFindCountry.Country.Russia,
                57, 65, 70, 15));
            players.Add(new Runner("Ksushka", "Lobonovich", IFindCountry.Country.Spain,
                55, 70, 55, 10));
            players.Add(new Runner("Mark", "Reshet", IFindCountry.Country.Russia,
                60, 79, 80, 30));


            //  Boxers
            players.Add(new Boxer("Khabib", "Nurmagamedov", IFindCountry.Country.Russia,
                90, 90, 20, 100));
            players.Add(new Boxer("Jon", "Jones", IFindCountry.Country.Spain,
                60, 70, 30, 75));
            players.Add(new Boxer("Kamaru", "Usman", IFindCountry.Country.Spain,
                63, 78, 28, 80));
            players.Add(new Boxer("Alexender", "Volkansi", IFindCountry.Country.Russia,
                73, 80, 35, 84));
            players.Add(new Boxer("Conor", "McGregor", IFindCountry.Country.Belarus,
                85, 80, 40, 95));
            players.Add(new Boxer("Vasya", "Vasichkin", IFindCountry.Country.Belarus,
                69, 65, 45, 71));
        }
        
        public static void AddPoints(string country, int numberPoints)
        {
            switch (country)
            {
                case "Belarus":
                    pointsBelarus += numberPoints;
                    break;
                case "Russia":
                    pointsRussia += numberPoints;
                    break;
                case "Spain":
                    pointsSpain += numberPoints;
                    break;
                case "Canada":
                    pointsCanada += numberPoints;
                    break;
                case "USA":
                    pointsUSA += numberPoints;
                    break;
                case "France":
                    pointsFrance += numberPoints;
                    break;
                case "Portugal":
                    pointsPortugal += numberPoints;
                    break;
                case "Jamaica":
                    pointsJamaica += numberPoints;
                    break;
            }
        }

        public static void ShowCountryPoints()
        {
            
            Console.WriteLine("\nCountries Points:");
            if (pointsBelarus > 0)
                Console.WriteLine("{0, -10}: {1, -10}", "Belarus", pointsBelarus.ToString());
            if (pointsRussia > 0)
                Console.WriteLine("{0, -10}: {1, -10}", "Russia", pointsRussia.ToString());
            if (pointsSpain > 0)
                Console.WriteLine("{0, -10}: {1, -10}", "Spain", pointsSpain.ToString());
            if (pointsJamaica > 0)
                Console.WriteLine("{0, -10}: {1, -10}", "Jamaica", pointsFrance.ToString());
            if (pointsPortugal > 0)
                Console.WriteLine("{0, -10}: {1, -10}", "Portugal", pointsCanada.ToString());
            if (pointsUSA > 0)
                Console.WriteLine("{0, -10}: {1, -10}", "USA", pointsUSA.ToString());
            if (pointsPortugal > 0)
                Console.WriteLine("{0, -10}: {1, -10}", "France", pointsPortugal.ToString());
            Console.WriteLine();
        }
    }
}