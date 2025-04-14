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
/* 
 * Joseph Lopotko & Dylan Joerres
 * CST-250
 * Milestone 4
 * 4/06/2025
 * Completed Together
 * Used TimeSpan code from Activity 5
 * Used code from Activity 6 for file dialog
 */
namespace MineSweeperGUI
{
    public partial class FrmSubmitScore : Form
    {
        //declare business logic
        BoardLogic boardLogic;
        // Declare and initialize
        private readonly int gameScore;
        private readonly TimeSpan gameTime;
        private string userName;

        /// <summary>
        /// parameterized constructor for FrmSubmitScore
        /// displays all passed stats in a label
        /// </summary>
        /// <param name="gameScore"></param>
        /// <param name="gameTime"></param>
        /// <param name="boardLogic"></param>
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
                FrmGameScores frmGameScores = new FrmGameScores(boardLogic);
                // Open FrmGameScores
                frmGameScores.ShowDialog();
                //close the submit score form
                this.Close();
                
            }
            else
            {
                // Show the warning
                lblWarning.Visible = true;
            }
        }
    }
}
