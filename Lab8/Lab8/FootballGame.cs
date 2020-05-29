using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab8
{
    // delegate for working with info about scored footballer and time scored
    public delegate void GoalScoredHandler(object sender, GoalEventArgs e);

    public class GoalEventArgs
    {
        public string NameScored;
        public string SurnameScored;
        public DateTime TimeScored;

        public GoalEventArgs(string name, string surname)
        {
            NameScored = name;
            SurnameScored = surname;
            TimeScored = DateTime.Now;
        }

    }

    public class FootballGame
    {
        // events fot broadcasting some info when game is playing
        public event GoalScoredHandler GoalScored;
        public event BroadcastHandler BroadcastingFootball;
        
        public void StartFootballGames(List<IScorer> footballers)
        {
            BroadcastingFootball?.Invoke("___Football Time!___\n");

            foreach (var country in Program.CountriesList)
            {
                BroadcastingFootball?.Invoke($"\n{country} players:");

                foreach (var footPlayer in footballers)
                {
                    if (footPlayer.CountryFrom == country)
                    {
                        BroadcastingFootball?.Invoke($"\t{footPlayer.Name} {footPlayer.Surname}");
                    }
                }

                Thread.Sleep(1200);
            }

            foreach (var country in Program.CountriesList)
            {
                BroadcastingFootball?.Invoke($"\n{country} is playing now!\n");
                Thread.Sleep(1300);

                foreach (var footPlayer in footballers)
                {
                    if (footPlayer.CountryFrom == country)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (footPlayer.IsScored())
                            {
                                // BroadcastingFootball?.Invoke($"Goal! Congratulations!" +
                                //                          $"{footPlayer.Name} {footPlayer.Surname} scored!");

                                GoalScored?.Invoke(this,
                                    new GoalEventArgs(footPlayer.Name, footPlayer.Surname));
                                
                                Program.AddPoints(country, 1);
                            }
                        }
                    }
                }

                BroadcastingFootball?.Invoke($"\n    {country} Played all games\n" +
                                         $"Waiting for the next match...");
                Thread.Sleep(2000);
            }

            BroadcastingFootball?.Invoke("\nFootball ended! All teams showed good work!\n" +
                                         "Now you can check Footballers in Football stats!");
        }
    }
}