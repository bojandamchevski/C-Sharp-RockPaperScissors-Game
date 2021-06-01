using System;

namespace RockPaperScissorsGame.App.Domain
{
    public class ComputerPlayer : BaseEntity
    {
        public ComputerPlayer()
        {

        }

        public override void Stats()
        {
            Console.WriteLine($"Player: {PlayerName}\n_____________\nWins: {Wins}\nDraws: {Draws}\nLosses: {Losses}");
        }
    }
}
