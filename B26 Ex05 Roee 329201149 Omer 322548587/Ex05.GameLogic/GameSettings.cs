using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.GameLogic
{
    public struct GameSettings
    {
        public int BoardSize { get; set; }
        public bool IsTwoPlayersMode { get; set; }
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }

        public GameSettings(int i_BoardSize, bool i_IsTwoPlayersMode, string i_Player1Name, string i_Player2Name)
        {
            this.BoardSize = i_BoardSize;
            this.IsTwoPlayersMode = i_IsTwoPlayersMode;
            this.Player1Name = i_Player1Name;
            this.Player2Name = i_Player2Name;
        }
    }
}
