using System;
using System.Collections.Generic;
using System.Text;

namespace rps_game.Interface
{

    public interface INameService
    {
        string GetNewRandomName(int syllableNo);
    }
}