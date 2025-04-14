using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MineSweeperClasses.Services.BusinessLogicLayer;

namespace MineSweeperGUI
{
    public partial class FrmSubmitScore : Form
    {
        //decalre business logic
        BoardLogic boardLogic;
        // Declare and initialize
        private readonly int gameScore;
        private readonly TimeSpan gameTime;
        private string userName;
        public FrmSubmitScore(int gameScore, TimeSpan gameTime, BoardLogic boardLogic)
        {
            InitializeComponent();

            // Pass in gameScore, gameTime & boardLogic object
            this.gameScore = gameScore;
            this.gameTime = gameTime;
            this.boardLogic = boardLogic;

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
                // Disable submission
                btnSubmit.Enabled = false;

                // Hide the warning
                lblWarning.Visible = false;

                // Submit the score
                userName = txtName.Text;
                boardLogic.AddHighScore(userName, gameScore, gameTime);


                // Instantiate FrmGameScores with submitted name, score, and time
                FrmGameScores frmGameScores = new FrmGameScores(userName, gameScore, gameTime);
                // Open FrmGameScores
                frmGameScores.ShowDialog();
                
            }
            else
            {
                // Show the warning
                lblWarning.Visible = true;
            }
        }
    }
}
