using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.GameLogic
{
    public class GameManager
    {
        /* =============== Fields =============== */
        private readonly Board r_Board;
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private readonly Random r_Random;

        /* =============== Properties =============== */
        public bool IsTwoPlayersMode { get; }

        public Player Winner { get; private set; }

        public Player CurrentPlayer { get; private set; }

        public int BoardSize
        {
            get
            {
                return r_Board.Size;
            }
        }

        public Player Player1
        {
            get
            {
                return r_Player1;
            }
        }

        public Player Player2
        {
            get
            {
                return r_Player2;
            }
        }


        /* =============== Constructor(s) =============== */

        public GameManager(GameSettings i_GameSettings)
        {
            r_Board = new Board(i_GameSettings.BoardSize);
            IsTwoPlayersMode = i_GameSettings.IsTwoPlayersMode;
            r_Player1 = new Player(i_GameSettings.Player1Name, Board.eCellState.X);
            r_Player2 = new Player(i_GameSettings.Player2Name, Board.eCellState.O);
            r_Random = new Random();
            Winner = null;
            CurrentPlayer = r_Player1;
            NewGame();
        }

        /* =============== Public Methods =============== */

        public void NewGame()
        {
            r_Board.ClearBoard();
            decideWinner();
        }

        public void SwitchTurn()
        {
            CurrentPlayer = (CurrentPlayer == r_Player1) ? r_Player2 : r_Player1;
        }

        public bool AutoMakeMove(out Board.Cell o_Cell)
        {
            bool isMoveSuccess = false;
            o_Cell = default;
            if (!r_Board.IsFull)
            {
                int cellIndex = r_Random.Next(0, r_Board.EmptyCells.Count);
                o_Cell = r_Board.EmptyCells.ElementAt(cellIndex);
                MakeMove(o_Cell);
                isMoveSuccess = true;
            }

            return isMoveSuccess;
        }

        public Board.eCellState GetCell(int i_Row, int i_Col)
        {
            return r_Board.GetCell(i_Row, i_Col);
        }

        public bool MakeMove(Board.Cell i_Cell)
        {
            return r_Board.SetCell(i_Cell.Row, i_Cell.Col, CurrentPlayer.Symbol);
        }

        public bool IsGameOver()
        {
            bool hasSequence = false;

            if (checkForSequence(out Board.eCellState symbol))
            {
                Winner = (symbol == r_Player1.Symbol) ? r_Player2 : r_Player1;
                Winner.Score++;
                hasSequence = true;
            }
            return hasSequence || r_Board.IsFull;
        }


        /* =============== Private Helper Methods =============== */

        private void decideWinner()
        {
            if (Winner == null)
            {
                CurrentPlayer = r_Player1;
            }
            else
            {
                CurrentPlayer = (Winner == r_Player1) ? r_Player2 : r_Player1;
            }
            Winner = null;
        }

        private bool checkForSequence(out Board.eCellState o_Symbol)
        {
            return checkMainDiagonal(out o_Symbol) || checkSecondaryDiagonal(out o_Symbol) || checkRowSequence(out o_Symbol) || checkColSequence(out o_Symbol);
        }

        private bool checkRowSequence(out Board.eCellState o_Symbol)
        {
            bool hasSequence = false;

            o_Symbol = Board.eCellState.Null;
            for(int row = 0; row < r_Board.Size; row++)
            {
                o_Symbol = r_Board.GetCell(row, 0);
                if(o_Symbol == Board.eCellState.Empty)
                {
                    continue;
                }
                hasSequence = true;
                for (int col = 1; col < r_Board.Size; col++)
                {
                    if (r_Board.GetCell(row, col) != o_Symbol)
                    {
                        hasSequence = false;
                        o_Symbol = Board.eCellState.Empty;
                        break;
                    }
                }
                if (hasSequence)
                {
                    break;
                }
            }
            
            return hasSequence;
        }
        private bool checkColSequence(out Board.eCellState o_Symbol)
        {
            bool hasSequence = false;

            o_Symbol = Board.eCellState.Null;
            for (int col = 0; col < r_Board.Size; col++)
            {
                o_Symbol = r_Board.GetCell(0, col);
                if(o_Symbol == Board.eCellState.Empty)
                {
                    continue;
                }
                hasSequence = true;
                for (int row = 1; row < r_Board.Size; row++)
                {
                    if (r_Board.GetCell(row, col) != o_Symbol)
                    {
                        hasSequence = false;
                        o_Symbol = Board.eCellState.Empty;
                        break;
                    }
                }
                if (hasSequence)
                {
                    break;
                }
            }
            
            return hasSequence;
        }
        private bool checkMainDiagonal(out Board.eCellState o_Symbol)
        {
            bool hasSequence = false;

            o_Symbol = r_Board.GetCell(0, 0);
            if (o_Symbol != Board.eCellState.Empty)
            {
                hasSequence = true;
                for(int i = 1; i < r_Board.Size; i++)
                {
                    if(r_Board.GetCell(i, i) != o_Symbol)
                    {
                        hasSequence = false;
                        o_Symbol = Board.eCellState.Empty;
                        break;
                    }
                }
            }

            return hasSequence;
        }

        private bool checkSecondaryDiagonal(out Board.eCellState o_Symbol)
        {
            bool hasSequence = false;

            o_Symbol = r_Board.GetCell(r_Board.Size - 1, 0);
            if (o_Symbol != Board.eCellState.Empty)
            {
                hasSequence = true;
                for (int i = 1; i < r_Board.Size; i++)
                {
                    if (r_Board.GetCell(r_Board.Size - i - 1, i) != o_Symbol)
                    {
                        hasSequence = false;
                        o_Symbol = Board.eCellState.Empty;
                        break;
                    }
                }
            }

            return hasSequence;
        }
    }
}
