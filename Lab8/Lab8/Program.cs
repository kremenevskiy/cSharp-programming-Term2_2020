using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Channels;

namespace Lab8
{
    // delegate for broadcasting all main info
    public delegate void BroadcastHandler(string newInfo);

    class Program
    {
        static StringBuilder FootballStats = new StringBuilder("\nFootball stats:\n");
        static StringBuilder BoxingStats = new StringBuilder("\nBoxing stats:\n");

        static List<Human> players = new List<Human>();
        private static List<IScorer> footballPlayers = null;
        private static List<IFighter<Boxer>> boxerPlayers = null;
        
        
        static void Main(string[] args)
        {
            FootballGame newFootballGame = new FootballGame();
            FightBattles newFightBattles = new FightBattles();

            // Adding lambda methods to events for reading data event sends
            newFootballGame.BroadcastingFootball += (x) => Console.WriteLine(x);
            newFightBattles.BroadcastingBoxing += (x) => Console.WriteLine(x);

            Boxer.BroadcastingMomentsBoxing += (x) => Console.WriteLine(x);
            
            Footballer.BroadcastingFootballCloseMoments += (x) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(x);
                Console.ResetColor();
            };
            
            // Anonymous functions for communicating with events
            newFootballGame.GoalScored += delegate(object sender, GoalEventArgs e)
            {
                FootballStats.AppendFormat($"\n{e.NameScored} {e.SurnameScored}" +
                                           $" scored at {e.TimeScored.ToString("HH:mm:ss")}\n");
            };

            newFightBattles.ResultBattle += delegate(object sender, ResultBattleEventArgs e)
            {
                BoxingStats.AppendFormat($"\nWinner: {e.WinnerName} {e.WinnerSurname} | {e.WinnerCountry}\n" +
                                         $"Loser: {e.LoserName} {e.LoserSurname} | {e.LoserCountry}\n");
            };
            
            
            while (true)
            {
                ShowMenu();
                int choice = GetNumber(8);

                switch (choice)
                {
                    case 1:
                        InitializeUpdatePlayers();
                        footballPlayers = players.OfType<IScorer>().ToList();
                        newFootballGame.StartFootballGames(footballPlayers);
                        
                        break;
                    case 2:
                        InitializeUpdatePlayers();
                        boxerPlayers = players.OfType<IFighter<Boxer>>().ToList();
                        newFightBattles.StartFightBattles(boxerPlayers);

                        break;
                    case 3:
                        ShowCountryPoints();
                        break;
                    case 4:
                        ShowFootballStats();
                        break;
                    case 5:
                        ShowBoxingStats();
                        break;
                    case 6:
                        ResetFootballStats();
                        break;
                    case 7:
                        ResetBoxingStats();
                        break;
                    case 8:
                        return;
                }
                WaitForPressKey();
            }
        }

        
        static void ShowFootballStats()
        {
            if (FootballStats.Length == 0 || FootballStats.Length == 17)
            {
                Console.WriteLine("\nStats are empty!\n" +
                                  "Start new Football Game to add some stats here!");
                return;
            }

            Console.WriteLine(FootballStats);
        }

        
        static void ShowBoxingStats()
        {
            if (BoxingStats.Length == 0 || BoxingStats.Length == 15)
            {
                Console.WriteLine("\nStats are empty!\n" +
                                  "Start new Boxing Battle to add some stats here!");
                return;
            }
            Console.WriteLine(BoxingStats);
        }

        
        static void ResetFootballStats()
        {
            FootballStats.Clear();
            FootballStats.Append("\nFootball stats:\n");
            Console.WriteLine("\nFootball stats are cleared successfully!");
        }

        
        static void ResetBoxingStats()
        {
            BoxingStats.Clear();
            BoxingStats.Append("\nBoxing stats:\n");
            Console.WriteLine("\nBoxing stats are cleared successfully!");
        }

        
        public static string[] CountriesList =
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

        static void ShowMenu()
        {
            Console.WriteLine("\n1. Start new Football game\n" +
                              "2. Start new Boxing battles\n" +
                              "3. Current countries Leaderboard\n" +
                              "4. Show Football stats\n" +
                              "5. Show Boxing stats\n" +
                              "6. Reset Football stats\n" +
                              "7. Reset Boxing stats\n" +
                              "8. Quit\n");
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
            if (pointsBelarus == 0 && pointsCanada == 0 && pointsFrance == 0 &&
                pointsJamaica == 0 && pointsPortugal == 0 && pointsRussia == 0 &&
                pointsSpain == 0 && pointsUSA == 0)
            {
                Console.WriteLine("\nNot a single match was played !\n" +
                                  "Leaderboard is empty!\n" +
                                  "Start boxing or football battle!");
                return;
            }
            
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


        static void InitializeUpdatePlayers()
        {
            players.Clear();
            Random rand = new Random();

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
            
            
            //  Boxers
            players.Add(new Boxer("Khabib", "Nurmagamedov", IFindCountry.Country.Russia,
                rand.Next(70, 90), rand.Next(70, 90), 20, rand.Next(80, 100)));
            players.Add(new Boxer("Jon", "Jones", IFindCountry.Country.Spain,
                rand.Next(50, 70), rand.Next(50, 75), 30, rand.Next(55, 75)));
            players.Add(new Boxer("Kamaru", "Usman", IFindCountry.Country.Spain,
                rand.Next(60, 75), rand.Next(55, 75), 28, rand.Next(60, 80)));
            players.Add(new Boxer("Alexender", "Volkansi", IFindCountry.Country.Russia,
                rand.Next(60, 80), rand.Next(60, 80), 35, rand.Next(60, 85)));
            players.Add(new Boxer("Conor", "McGregor", IFindCountry.Country.Belarus,
                rand.Next(70, 85), rand.Next(70, 85), 40, rand.Next(80, 95)));
            players.Add(new Boxer("Vasya", "Vasichkin", IFindCountry.Country.Belarus,
                rand.Next(40, 60), rand.Next(50, 75), 45, rand.Next(50, 75)));
        }


        static int GetNumber(int option)
        {
            int number;
            while (true)
            {
                Console.Write("Enter: ");
                if (!(int.TryParse(Console.ReadLine(), out number) && number > 0 && number <= option))
                {
                    Console.WriteLine("Wrong input. Try again!");
                    continue;
                }
                else
                {
                    break;
                }
            }
            
            return number;
        }

        
        static void WaitForPressKey()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }
    }
}