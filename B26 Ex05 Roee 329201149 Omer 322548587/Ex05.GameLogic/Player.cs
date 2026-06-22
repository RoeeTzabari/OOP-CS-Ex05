using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.GameLogic
{
    public class Player
    {
        private string m_Name;
        public string Name
        {
            get
            {
                return m_Name;
            }
        }
        public Board.eCellState Symbol { get; }
        public ushort Score { get; set; }

        public Player(string i_Name, Board.eCellState i_Symbol)
        {
            m_Name = i_Name;
            Symbol = i_Symbol;
        }
    }
}
