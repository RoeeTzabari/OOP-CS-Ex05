using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.GameGUI
{
    // $G$ SFN-010 (-7) When a player quits the program won't add points to the other player.
    // $G$ SFN-012 (-7) The program does not allow another new game, after a player quits.
    class Program
    {
        static void Main(string[] args)
        {
            FormGameSettings gameSettings = new FormGameSettings();
            gameSettings.ShowDialog();
            if (gameSettings.DialogResult == DialogResult.OK)
            {
                FormGame game = new FormGame(gameSettings.GetGameSettings());
                game.StartGame();
            }
        }
    }
}
