using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab8
{
    // delegate to work later with info about loser and winner in battle
    public delegate void ResultsFightHandler(object sender, ResultBattleEventArgs e);
    
    public class ResultBattleEventArgs
    {
        public readonly string WinnerName;
        public readonly string WinnerSurname;
        
        public readonly string LoserName;
        public readonly string LoserSurname;
        
        public readonly string WinnerCountry;
        public readonly string LoserCountry;
        

        public ResultBattleEventArgs(string winnerName, string winnerSurname, string winnerCountry,
            string loserName, string loserSurname, string loserCountry)
        {
            WinnerName = winnerName;
            WinnerSurname = winnerSurname;
            WinnerCountry = winnerCountry;
            
            LoserName = loserName;
            LoserSurname = loserSurname;
            LoserCountry = loserCountry;
        }
    }
    
    public class FightBattles
    {
        // events for broadcasting some information while game is playing
        public event BroadcastHandler BroadcastingBoxing;
        public event ResultsFightHandler ResultBattle;
        
        public void StartFightBattles(List<IFighter<Boxer>> boxers)
        {
            BroadcastingBoxing?.Invoke("___Boxing Starting!___\n");
            BroadcastingBoxing?.Invoke("Boxers:");
            foreach (var boxer in boxers)
            {
                BroadcastingBoxing?.Invoke(string.Format("{0, -20} | {1, -10}", $"{boxer.Name} {boxer.Surname}",
                    $"Country: {boxer.CountryFrom}"));
            }
            Thread.Sleep(3000);
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
                        {
                            ResultBattle?.Invoke(this, 
                                new ResultBattleEventArgs(boxer.Name, boxer.Surname,
                                    boxer.CountryFrom, opponent.Name,
                                    opponent.Surname, opponent.CountryFrom));
                            
                            Program.AddPoints(boxer.CountryFrom, 1);
                        }
                        else
                        {
                            ResultBattle?.Invoke(this, 
                                new ResultBattleEventArgs(opponent.Name, opponent.Surname, 
                                    opponent.CountryFrom,  boxer.Name,
                                    boxer.Surname, boxer.CountryFrom));
                            
                            Program.AddPoints(opponent.CountryFrom, 1);
                        }
                    }
                }
            }
            BroadcastingBoxing?.Invoke("Done battles for today\n" +
                                       "Now can check Boxing stats to view all battles results for all time");
        }
    }
}