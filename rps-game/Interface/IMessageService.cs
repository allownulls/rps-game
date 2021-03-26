using System;
using System.Collections.Generic;
using System.Text;

namespace rps_game.Interface
{

    public interface IMessageService
    {
        string ReadPlayerType(int no);

        string ReadPlayerName(int no);

        string ReadPlayerChoice();

        void WritePlayer(string type, string name);

        void WritePlayerExists(string name);

        void WritePlayerTurn(string name);

        void WritePlayerChoice(string name, string choice);

        void WriteGameWinner(string name);

        void WriteGameWinner();
    }
}