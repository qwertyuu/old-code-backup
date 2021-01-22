using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MC_Server_utility
{
    class Writer
    {

        internal static void WriteConfigFile(int _difficulty, string _seed, string _worldName, decimal _MaxPlayer, decimal _Port, int _GameMode, string _motd, decimal _spawnSize, int _mapType, bool[] _checkedConfigs, string path)
        {
            StreamWriter swProp = new StreamWriter(path + "\\server.properties");
            swProp.WriteLine("allow-nether=" + _checkedConfigs[0].ToString().ToLower());
            swProp.WriteLine("spawn-npcs=" + _checkedConfigs[1].ToString().ToLower());
            swProp.WriteLine("white-list=" + _checkedConfigs[2].ToString().ToLower());
            swProp.WriteLine("spawn-animals=" + _checkedConfigs[3].ToString().ToLower());
            swProp.WriteLine("hardcode=" + _checkedConfigs[4].ToString().ToLower());
            swProp.WriteLine("online-mode=" + (!_checkedConfigs[5]).ToString().ToLower());
            swProp.WriteLine("pvp=" + _checkedConfigs[6].ToString().ToLower());
            swProp.WriteLine("spawn-monsters=" + _checkedConfigs[7].ToString().ToLower());
            swProp.WriteLine("generate-structure=" + _checkedConfigs[8].ToString().ToLower());
            swProp.WriteLine("level-name=" + WorldName(_worldName.Trim()));
            swProp.WriteLine("server-port=" + _Port);
            swProp.WriteLine("level-type=" + GetLevelType(_mapType));
            swProp.WriteLine("level-seed=" + _seed.Trim());
            swProp.WriteLine("difficulty=" + GetDifficulty(_difficulty));
            swProp.WriteLine("gamemode=" + _GameMode);
            swProp.WriteLine("max-players=" + _MaxPlayer);
            swProp.WriteLine("motd=" + _motd);
            swProp.Close();
        }

        private static string WorldName(string p)
        {
            if (p == string.Empty)
            {
                return "world";
            }
            else
            {
                return p;
            }
        }

        internal static void WriteOpsFile(string _ops, string path)
        {
            string toWrite = _ops.Replace("\n", "\r\n");
            StreamWriter swOps = new StreamWriter(path + "\\ops.txt");
            swOps.Write(toWrite);
            swOps.Close();
        }

        private static int GetDifficulty(int _difficulty)
        {
            if (_difficulty == 3)
            {
                return 0;
            }
            else
            {
                return _difficulty + 1;
            }
        }

        private static string GetLevelType(int _mapType)
        {
            if (_mapType == 1)
            {
                return "FLAT";
            }
            else if (_mapType == 2)
            {
                return "LARGEBIOMES";
            }
            else
            {
                return "DEFAULT";
            }
        }
    }
}
