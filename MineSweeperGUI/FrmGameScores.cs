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
    public partial class FrmGameScores : Form
    {
        // Instantiate ScoreLogic
        private ScoreLogic _scoreLogic;

        /// <summary>
        /// Form Constructor, accepts submitted score
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="gameScore"></param>
        /// <param name="time"></param>
        public FrmGameScores(string userName = "", int gameScore = 0, TimeSpan? time = null)
        {
            InitializeComponent();
            // Initialize ScoreLogic
            _scoreLogic = new ScoreLogic();
            // Load high scores into our datagrid
            dgvGameScores.DataSource = _scoreLogic.GetHighScores();
        }

        /// <summary>
        /// Click EH to manually save the current scores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmSaveClickEH(object sender, EventArgs e)
        {
            // Open a save file dialog, with a filter accepting .txt files
            // and give a title for the dialog
            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "Save Highscores"
            };

            // If the file selection is a success, let the user know
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string message = _scoreLogic.WriteHighScoresToFile(sfd.FileName);
                MessageBox.Show(message);
            }
        }

        /// <summary>
        /// Click EH to load scores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmLoadClickEH(object sender, EventArgs e)
        {
            // Open an open file dialog, with a filter accepting .txt files
            // and give a title for the dialog
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "Load Highscores"
            };

            // If the file selection is a success, let the user know.
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Message to show based on returned result
                //string message = _scoreLogic.ReadHighScoresFromFile(ofd.FileName);
                MessageBox.Show(_scoreLogic.ReadHighScoresFromFile(ofd.FileName));
                // Refresh datasource
                dgvGameScores.DataSource = null;
                // Get the scores
                dgvGameScores.DataSource = _scoreLogic.GetHighScores();
            }
        }

        /// <summary>
        /// Click EH to sort by name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmByNameClickEH(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Click EH to sort by score (highest to lowest)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmByScoreClickEH(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Click EH to sort by time (fastest)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmByTimeClickEH(object sender, EventArgs e)
        {

        }
    }
}
