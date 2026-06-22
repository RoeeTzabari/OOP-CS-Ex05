using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex05.GameLogic;

namespace Ex05.GameGUI
{
    public partial class FormGameSettings : Form
    {
        private string m_Player1Name = "Player 1";
        public string Player1Name
        {
            get
            {
                return m_Player1Name;
            }
        }

        private string m_Player2Name = "[Computer]";
        public string Player2Name
        {
            get
            {
                return m_Player2Name;
            }
        }

        public FormGameSettings()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            this.Text = "Game Settings";
        }

        public GameSettings GetGameSettings()
        {
            return new GameSettings((int)m_NumericUpDownCols.Value, m_CheckBoxPlayer2.Checked, Player1Name, Player2Name);
        }

        private void textBoxPlayer1_TextChanged(object sender, EventArgs e)
        {
            string value = (sender as TextBox).Text;

            m_Player1Name = value == String.Empty ? "Player 1" : value;
        }

        private void textBoxPlayer2_TextChanged(object sender, EventArgs e)
        {
            string value = (sender as TextBox).Text;

            m_Player2Name = value == String.Empty ? "Player 2" : value;
        }

        private void checkBoxPlayer2_CheckStateChanged(object sender, EventArgs e)
        {
            bool checkedStatus = (sender as CheckBox).Checked;

            if(!checkedStatus)
            {
                m_TextBoxPlayer2.Enabled = false;
                m_TextBoxPlayer2.Text = "[Computer]";
            }
            else
            {
                m_TextBoxPlayer2.Enabled = true;
                m_TextBoxPlayer2.Text = "";
            }
        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            decimal value = (sender as NumericUpDown).Value;

            m_NumericUpDownCols.Value = value;
        }

        private void numericUpDownCols_ValueChanged(object sender, EventArgs e)
        {
            decimal value = (sender as NumericUpDown).Value;

            m_NumericUpDownRows.Value = value;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
