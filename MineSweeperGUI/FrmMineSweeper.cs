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
        TimeSpan timeSpan = new TimeSpan();
        bool gameOn = false;

        public FrmMineSweeper(Board gameBoard)
        {
            InitializeComponent();
            board = gameBoard;
            // Call method to set up buttons
            SetUpButtons();
            // Setup the game's time label
            lblTime.Text = timeSpan.ToString();
        }

        /// <summary>
        /// Set up the game buttons
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
                    // Set button color
                    buttons[row, col].BackColor = SystemColors.Control;
                    // Assign cell click event handler to each button
                    buttons[row, col].Click += BtnCellClickEH;
                    // Tag a point to each button
                    buttons[row, col].Tag = new Point(row, col);
                    // Add the buttons to the game panel
                    pnlGame.Controls.Add(buttons[row, col]);
                }
            }
        }

        /// <summary>
        /// Click event handler for buttons
        /// Soon as the first button is clicked, the game timer will start.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCellClickEH(object sender, EventArgs e)
        {
            // If the game hasn't been started yet
            if (!gameOn)
            {
                // Mark game as started, then start the game timer.
                gameOn = true;

            }
            // Declare and initialize
            // Cast the sender object to a Button
            Button button = (Button)sender;
            // Retreive Tag property of button
            Point point = (Point)button.Tag;
            // Extract the row and col values from the Point object
            int row = point.X;
            int col = point.Y;

            // Display choice to user
            MessageBox.Show($"Cell {row},{col} has been selected");


        }

        /// <summary>
        /// Counts the time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrStopwatchTickEH(object sender, EventArgs e)
        {

        }
    }
}
