/* 
 * Joseph Lopotko & Dylan Joerres
 * CST-250
 * Milestone 4
 * 2/26/2025
 * Completed Together
 */
using MineSweeperClasses.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperGUI
{

    public partial class FrmGameSettings : Form
    {
        public Board board;

        public FrmGameSettings()
        {
            InitializeComponent();
            int boardSize = -1;
            int boardDifficulty = -1;
        }

        private void TrkSizeBoardValueChangedEH(object sender, EventArgs e)
        {
            lblSize.Text = trkSizeBoard.Value.ToString();
            board.Size = trkSizeBoard.Value;
        }

        private void DifficultyCheckedChangedEH(object sender, EventArgs e)
        {
            // Get the radio button from sender object
            RadioButton radioButton = sender as RadioButton;

            // make sure the radio button isn't null

            if (radioButton != null && radioButton.Checked)
            {
                board.Size = int.Parse(radioButton.Text);
            }
        }
    }
}
