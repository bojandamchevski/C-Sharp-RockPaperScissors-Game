using RockPaperScissorsGame.App.Domain;
using System;

namespace RockPaperScissorsGame.App.Services
{
    public class PlayerService<T> : Database<T> where T : BaseEntity
    {
        private Database<T> _database;

        public PlayerService()
        {
            _database = new Database<T>();
        }
        public static void GenerateText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public void AddNewPlayer(T player)
        {
            _database.AddPlayer(player);
        }
        public void MainMenu()
        {
            while (true)
            {
                GenerateText("Welcome to the game Rock Paper Scissors !\n\n\n", ConsoleColor.Yellow);
                GenerateText("1.) Play a game", ConsoleColor.Yellow);
                GenerateText("    [Enter 1 to play a game]", ConsoleColor.DarkYellow);
                GenerateText("2.) View stats", ConsoleColor.Yellow);
                GenerateText("    [Enter 2 to view game stats]", ConsoleColor.DarkYellow);
                GenerateText("3.) Exit", ConsoleColor.Yellow);
                GenerateText("    [Enter 3 to exit]", ConsoleColor.DarkYellow);
                bool mainMenuChoiceValidation = int.TryParse(Console.ReadLine(), out int mainMenuChoice);
                if (mainMenuChoiceValidation)
                {
                    if (mainMenuChoice == 1)
                    {
                        Gameplay();
                    }
                    else if (mainMenuChoice == 2)
                    {

                        GameStats();
                    }
                    else if (mainMenuChoice == 3)
                    {
                        break;
                    }
                }
                else
                {
                    Console.Clear();
                    GenerateText("Bad input, please enter a number.\nPress any key to continue.", ConsoleColor.Red);
                    Console.ReadKey();
                }
            }
        }
        public int ComputerMove()
        {
            int computerMove = new Random().Next(1, 3);
            return computerMove;
        }
        public void Gameplay()
        {
            while (true)
            {
                Console.Clear();
                T player = _database.FindPlayer("Player1");
                T computerPlayer = _database.FindPlayer("ComputerPlayer");
                GenerateText("Choose a move:\n\n", ConsoleColor.Yellow);
                GenerateText("1.) Rock        2.) Paper        3.) Scissors", ConsoleColor.Yellow);
                bool moveValidation = int.TryParse(Console.ReadLine(), out int move);
                if (moveValidation)
                {
                    if ((move == 1 && ComputerMove() == 1) || (move == 2 && ComputerMove() == 2) || (move == 3 && ComputerMove() == 3))
                    {
                        player.GamesPlayed++;
                        player.Draws++;
                        computerPlayer.GamesPlayed++;
                        computerPlayer.Draws++;
                        _database.UpdateComputer(computerPlayer);
                        _database.UpdatePlayer(player);
                        GenerateText("It's a draw.", ConsoleColor.DarkGray);
                        GenerateText("\n\nPress any key to continue.", ConsoleColor.Green);
                        Console.ReadKey();
                    }
                    else if ((move == 1 && ComputerMove() == 3) || (move == 2 && ComputerMove() == 1) || (move == 3 && ComputerMove() == 2))
                    {
                        player.GamesPlayed++;
                        player.Wins++;
                        computerPlayer.GamesPlayed++;
                        computerPlayer.Losses++;
                        _database.UpdateComputer(computerPlayer);
                        _database.UpdatePlayer(player);
                        GenerateText("You win !!!", ConsoleColor.Green);
                        GenerateText("\n\nPress any key to continue.", ConsoleColor.Green);
                        Console.ReadKey();
                    }
                    else if ((move == 3 && ComputerMove() == 1) || (move == 1 && ComputerMove() == 2) || (move == 2 && ComputerMove() == 3))
                    {
                        player.GamesPlayed++;
                        player.Losses++;
                        computerPlayer.GamesPlayed++;
                        computerPlayer.Wins++;
                        _database.UpdateComputer(computerPlayer);
                        _database.UpdatePlayer(player);
                        GenerateText("The computer won...", ConsoleColor.Blue);
                        GenerateText("\n\nPress any key to continue.", ConsoleColor.Green);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        GenerateText("Invalid move (Must be between 1 and 3). Try again !\nPress any key to try again", ConsoleColor.Red);
                        Console.ReadKey();
                    }
                }
                else
                {
                    GenerateText("Invalid move, try again.\nPress any key to try again.", ConsoleColor.Red);
                    Console.ReadKey();
                }
            }
        }
        public void GameStats()
        {
            T player = _database.FindPlayer("Player1");
            Console.ForegroundColor = ConsoleColor.Cyan;
            player.Stats();
            T computerPlayer = _database.FindPlayer("ComputerPlayer");
            computerPlayer.Stats();
            GenerateText("\n\nPress any key to continue.", ConsoleColor.Green);
            Console.ReadKey();
        }
    }
}
