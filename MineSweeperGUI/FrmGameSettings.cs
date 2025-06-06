﻿/* 
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
        // Declare and Initialize boardSize and boardDifficulty to be passed
        int boardSize = 4;
        int boardDifficulty = -1;

        
        /// <summary>
        /// default constructor
        /// </summary>
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
            boardSize = trkSizeBoard.Value;
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
                        boardDifficulty = 1;
                        break;
                    case "radMedium":
                        boardDifficulty = 2;
                        break;
                    case "radDifficult":
                        boardDifficulty = 3;
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
            if (boardDifficulty > 0)
            {
                // Disable start game button, disable inputs for size and difficulty
                btnStartGame.Enabled = false;
                trkSizeBoard.Enabled = false;
                grpLevel.Enabled = false;
                // Instantiate a board with the chosen values
                Board board = new Board(boardSize, boardDifficulty);
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

        /// <summary>
        /// Button to exit the game settings form and game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExitClickEH(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }
    }
}
