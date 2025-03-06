/* 
 * Joseph Lopotko & Dylan Joerres
 * CST-250
 * Milestone 4
 * 2/26/2025
 * Completed Together
 */
using MineSweeperClasses.Models;
using MineSweeperClasses.Services.BusinessLogicLayer;

namespace MineSweeperGUI
{
    public partial class FrmMineSweeper : Form
    {
        // Class level variables
        private Board board;

        
        public FrmMineSweeper(Board gameBoard)
        {
            InitializeComponent();
            board = gameBoard;
            SetUpButtons();
        }
        
        /// <summary>
        /// Set up the buttons
        /// </summary>
        private void SetUpButtons()
        {
            // Declare and Initialize
            // Calculate the size of each button based on
            // the panel width and number of buttons needed.
            int buttonSize = pnlGame.Height / board.Size;
            //pnlGame.Width = (board.Size * 100);
            // Set the panel to be square
            pnlGame.Width = pnlGame.Height;

            // Nested for loop to loop through the boards Grid
            for (int row = 0; row < board.Size; row++)
            {
                // Set up each individual button
                for (int col = 0; col < board.Size; col++)
                {
                    Button[,] buttons = new Button[board.Size, board.Size];
                    // Create a new button in the 2D array
                    buttons[row, col] = new Button();
                    // Set the size of the button
                    buttons[row, col].Width = buttonSize;
                    buttons[row, col].Height = buttonSize;
                    // Set the location of the button
                    // use the left and top sides
                    buttons[row, col].Left = row * buttonSize;
                    buttons[row, col].Top = col * buttonSize;
                    buttons[row, col].BackColor = SystemColors.Control;

                    pnlGame.Controls.Add(buttons[row, col]);
                }
            }
        }
    }
}
