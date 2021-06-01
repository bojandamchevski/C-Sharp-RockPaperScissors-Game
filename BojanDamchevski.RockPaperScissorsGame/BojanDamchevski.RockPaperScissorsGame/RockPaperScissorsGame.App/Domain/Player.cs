using System;

namespace RockPaperScissorsGame.App.Domain
{
    public class Player : BaseEntity
    {
        public Player(string playerName)
        {
            PlayerName = playerName; 
        }

        public override void Stats()
        {
            Console.WriteLine($"Player: {PlayerName}\n_____________\nWins: {Wins}\nDraws: {Draws}\nLosses: {Losses}");
        }
    }
}
