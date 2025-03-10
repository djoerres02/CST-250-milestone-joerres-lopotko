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
        // Initialize bool determining whether to start game along with values to track the settings
        bool StartGame = false;
        int Size = 4;
        int Difficulty = -1;

        // Setup board
        //public Board board { get; set; }

        public FrmGameSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Value changed event handler for trackbar value changing
        /// this allows us to retrieve the user's desired board size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrkSizeBoardValueChangedEH(object sender, EventArgs e)
        {
            lblSize.Text = trkSizeBoard.Value.ToString();
            Size = trkSizeBoard.Value;
        }

        /// <summary>
        /// Checked changed event handler for radio buttons
        /// allows receiving of difficulty based on radio button name respective to difficulty integer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DifficultyCheckedChangedEH(object sender, EventArgs e)
        {
            // Get the radio button from sender object
            RadioButton radioButton = sender as RadioButton;

            // make sure the radio button isn't null and is checked
            if (radioButton != null && radioButton.Checked)
            {
                // based on selected radio button, assign difficulty
                switch (radioButton.Name)
                {
                    case "radEasy":
                        Difficulty = 1;
                        break;
                    case "radMedium":
                        Difficulty = 2;
                        break;
                    case "radDifficult":
                        Difficulty = 3;
                        break;
                    default:
                        MessageBox.Show("Error, invalid difficulty");
                        break;
                }
            }
        }

        /// <summary>
        /// Click event handler to start the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartGameClickEH(object sender, EventArgs e)
        {
            // Ensure the user has a board difficulty selected
            // Initial board difficulty is set to 0, a placeholder
            if (Difficulty > 0)
            {
                // Disable the game settings form
                this.Enabled = false;
                //instantiate a board with the chosen values
                Board board = new Board(Size, Difficulty);
                // Create an instance of frmMineSweeper with board passed in
                FrmMineSweeper frmMineSweeper = new FrmMineSweeper(board);
                // Show the minesweeper game
                frmMineSweeper.Show();
            }
            else
            {
                // Inform the user to select a difficulty
                MessageBox.Show("Please ensure a difficulty is selected.");
            }
        }
    }
}
