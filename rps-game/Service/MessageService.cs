using System;
using rps_game.Interface;

namespace rps_game.Service
{
    public class MessageService : IMessageService
    {
        public string ReadPlayerType(int no)
        {
            Console.WriteLine();
            Console.WriteLine($"Enter player {no} type (1: Human / 2: Computer)");
            return Console.ReadLine();
        }

        public string ReadPlayerName(int no)
        {
            Console.WriteLine();
            Console.WriteLine($"Enter player {no} name (max 10 symbols)");
            return Console.ReadLine();
        }

        public string ReadPlayerChoice() => Console.ReadLine();

        public void WritePlayer(string type, string name) => Console.WriteLine($"{type} player: {name}");

        public void WritePlayerTurn(string name)
        {
            Console.WriteLine();
            Console.WriteLine($"{name} player turn (1: Rock / 2: Paper / 3: Scissors)");
        }

        public void WritePlayerChoice(string name, string choice) => Console.WriteLine($"{name} choice: {choice}");

        public void WriteGameWinner(string name)
        {
            Console.WriteLine();
            Console.WriteLine($"{name} wins!");
        }

        public void WriteGameWinner()
        {
            Console.WriteLine();
            Console.WriteLine($"Draw! Rematch?");
        }

        public void WritePlayerExists(string name) => Console.WriteLine($"Sorry, the name {name} is already taken");

    }
}
