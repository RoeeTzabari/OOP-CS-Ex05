using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.GameGUI
{
    public partial class FormGameSettings : Form
    {
        private string m_Player1Name;
        public string Player1Name
        {
            get
            {
                return m_Player1Name;
            }
        }

        private string m_Player2Name;
        public string Player2Name
        {
            get
            {
                return m_Player2Name;
            }
        }

        private bool m_TwoPlayers;
        public bool TwoPlayers
        {
            get
            {
                return m_TwoPlayers;
            }
        }

        private decimal m_NumOfRows;
        public decimal NumOfRows
        {
            get
            {
                return m_NumOfRows;
            }
        }

        private decimal m_NumOfCols;
        public decimal NumOfCols
        {
            get
            {
                return m_NumOfCols;
            }
        }

        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void textBoxPlayer1_TextChanged(object sender, EventArgs e)
        {
            m_Player1Name = (sender as TextBox).Text ?? "Player 1";
        }

        private void textBoxPlayer2_TextChanged(object sender, EventArgs e)
        {
            m_Player2Name = (sender as TextBox).Text ?? "Player 2";
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            bool checkedStatus = (sender as CheckBox).Checked;

            m_TwoPlayers = checkedStatus;
            if(!checkedStatus)
            {
                m_Player2Name = "[Computer]";
            }
        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            decimal value = (sender as NumericUpDown).Value;

            m_NumericUpDownCols.Value = value;
            m_NumOfRows = value;
            m_NumOfCols = value;
        }

        private void numericUpDownCols_ValueChanged(object sender, EventArgs e)
        {
            decimal value = (sender as NumericUpDown).Value;

            m_NumericUpDownRows.Value = value;
            m_NumOfRows = value;
            m_NumOfCols = value;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

        }
    }
}
