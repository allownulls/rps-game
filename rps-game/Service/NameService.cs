using System;
using System.Linq;
using rps_game.Interface;

namespace rps_game.Service
{
    public class NameService: INameService
    {
        private const string cons = "bcdfghjklmnpqrstvwxz";
        private const string vow = "aeiouy";

        public string GetNewRandomName(int syllableNo)
        {
            string ret = "";

            for (var i = 0; i < syllableNo; i++)
            {
                var rand = new Random(Guid.NewGuid().GetHashCode());
                ret += $"{cons[rand.Next(cons.Length)]}{vow[rand.Next(vow.Length)]}";
            }
            
            return $"{ret[0].ToString().ToUpper()}{ret.Substring(1)}";
        }

    }
}
