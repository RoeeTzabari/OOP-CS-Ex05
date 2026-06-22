using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.GameLogic
{
    public class Player
    {
        public Board.eCellState Symbol { get; }
        public ushort Score { get; set; }

        public Player(Board.eCellState i_Symbol)
        {
            Symbol = i_Symbol;
        }
    }
}
