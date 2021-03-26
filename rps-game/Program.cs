using System;
using Microsoft.Extensions.DependencyInjection;
using rps_game.Interface;
using rps_game.Class;
using rps_game.Service;


namespace rps_game
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IRoundService, RoundService>()
            .AddSingleton<IResultsService, ResultsService>()
            .AddSingleton<ITurnService, TurnService>()
            .AddSingleton<IPlayerService, PlayerService>()
            .AddSingleton<IMessageService, MessageService>()
            .AddSingleton<INameService, NameService>()
            .BuildServiceProvider();

            _ = serviceProvider.GetService<INameService>();

            var resultService = serviceProvider.GetService<IResultsService>();
            var roundService = serviceProvider.GetService<IRoundService>();            
            var playerService = serviceProvider.GetService<IPlayerService>();
            var messageService = serviceProvider.GetService<IMessageService>();
            
            Game game = new Game(resultService, roundService,playerService, messageService);
            game.Play();

            Console.ReadLine();
        }
    }
}
