using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Ex05.GameLogic;

namespace Ex05.GameGUI
{
    public partial class FormGame : Form
    {
        private GameManager m_Game;
        private int m_BoardSize;

        public FormGame(GameSettings i_GameSettings)
        {
            InitializeComponent();
            this.Text = "TicTacToeMisere";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.m_Game = new GameManager(i_GameSettings);
            m_BoardSize = i_GameSettings.BoardSize;
        }

        public void StartGame()
        {
            initializeBoard();
            updateScoreBoard();
            this.ShowDialog();
        }

        private void updateScoreBoard()
        {
            this.m_LabelScoreBoard.Text = $"{m_Game.Player1.Name}:{m_Game.Player1.Score}    {m_Game.Player2.Name}:{m_Game.Player2.Score}";
        }

        private void initializeBoard()
        {
            float percentPerCell = 100f / m_BoardSize;

            m_TableLayoutPanel.ColumnStyles.Clear();
            m_TableLayoutPanel.RowStyles.Clear();
            m_TableLayoutPanel.RowCount = m_BoardSize;
            m_TableLayoutPanel.ColumnCount = m_BoardSize;

            // Create Table
            for (int i = 0; i < m_BoardSize; i++)
            {
                m_TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percentPerCell));
                m_TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, percentPerCell));
            }

            // Add Buttons
            for (int row = 0; row < m_BoardSize; row++)
            {
                for(int col = 0; col < m_BoardSize; col++)
                {
                    Button cellButton = new Button();

                    cellButton.Dock = DockStyle.Fill;
                    cellButton.Click += new EventHandler(buttonBoardCells_Click);
                    cellButton.Tag = new Board.Cell(row, col);
                    m_TableLayoutPanel.Controls.Add(cellButton, col, row);
                }
            }
        }

        // TODO: Add GameOver check, Scoreboard update, GameOver form that appears when the game is over, ...
        private void buttonBoardCells_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            button.Text = m_Game.CurrentPlayer.Symbol.ToString();
            button.Enabled = false;
            m_Game.MakeMove((Board.Cell)button.Tag);
            m_Game.SwitchTurn();
        }
    }
}
