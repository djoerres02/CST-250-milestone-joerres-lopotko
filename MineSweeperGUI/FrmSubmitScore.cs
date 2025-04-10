using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperGUI
{
    public partial class FrmSubmitScore : Form
    {
        // Declare and initialize
        private readonly int gameScore;
        private readonly TimeSpan gameTime;
        public FrmSubmitScore(int gameScore, TimeSpan gameTime)
        {
            InitializeComponent();

            // Pass in gameScore & gameTime
            this.gameScore = gameScore;
            this.gameTime = gameTime;

            // Pass in the game stats to lblStats
            lblStats.Text = $"You have ended with {gameScore} points in {gameTime.ToString()}!";
        }

        /// <summary>
        /// Click EH to submit user's name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmitClickEH(object sender, EventArgs e)
        {
            // If the input name isn't null or white space
            if (!String.IsNullOrWhiteSpace(txtName.Text))
            {
                // Hide the warning
                lblWarning.Visible = false;

                // Submit the score

            }
            else
            {
                // Show the warning
                lblWarning.Visible = true;
            }
        }
    }
}
