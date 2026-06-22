using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.GameLogic
{
    public class Board
    {
        public enum eCellState
        {
            Null = 0,
            Empty,
            X,
            O,
        }

        public readonly struct Cell
        {
            public int Row { get; }
            public int Col { get; }

            public Cell(int i_Row, int i_Col)
            {
                Row = i_Row;
                Col = i_Col;
            }

            public override bool Equals(object i_Obj)
            {
                return i_Obj is Cell otherCell && otherCell.Row == this.Row && otherCell.Col == this.Col;
            }
        }

        /* =============== Fields =============== */
        private readonly eCellState[,] r_Matrix;

        /* =============== Properties =============== */
        public int Size { get; }

        public bool IsFull
        {
            get
            {
                return EmptyCells.Count == 0;
            }
        }

        public List<Cell> EmptyCells { get; }

        /* =============== Constructor(s) =============== */
        public Board() : this(3)
        {

        }

        public Board(int i_Size)
        {
            r_Matrix = new eCellState[i_Size,i_Size];
            Size = i_Size;
            EmptyCells = new List<Cell>();

            ClearBoard();
        }

        /* =============== Public Methods =============== */


        public void ClearBoard()
        {
            EmptyCells.Clear();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    r_Matrix[i,j] = eCellState.Empty;
                    EmptyCells.Add(new Cell(i, j));
                }
            }
        }

        public bool SetCell(int i_Row, int i_Col, eCellState i_CellState)
        {
            bool success = false;
            bool isValidInput = i_Row >= 0 && i_Row < Size && i_Col >= 0 && i_Col < Size;

            if (isValidInput && r_Matrix[i_Row, i_Col] == eCellState.Empty)
            {
                r_Matrix[i_Row, i_Col] = i_CellState;
                success = EmptyCells.Remove(new Cell(i_Row, i_Col));
            }

            return success;
        }

        public eCellState GetCell(int i_Row, int i_Col)
        {
            eCellState cellState = eCellState.Null;

            if (i_Row >= 0 && i_Row < Size && i_Col >= 0 && i_Col < Size)
            {
                cellState = r_Matrix[i_Row, i_Col];
            }

            return cellState;
        }
    }
}
