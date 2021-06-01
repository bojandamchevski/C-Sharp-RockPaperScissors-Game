using RockPaperScissorsGame.App.Domain;
using RockPaperScissorsGame.App.Services;
using System;

namespace RockPaperScissorsGame.App
{
    class Program
    {
        public static PlayerService<Player> playerService = new PlayerService<Player>();
        public static PlayerService<ComputerPlayer> playerServiceCom = new PlayerService<ComputerPlayer>();
        
        static void Main(string[] args)
        {
            //playerService.AddNewPlayer(new Player("Player1"));
            //playerServiceCom.AddNewPlayer(new ComputerPlayer() { PlayerName = "ComputerPlayer" });
            playerService.MainMenu();
        }
    }
}
