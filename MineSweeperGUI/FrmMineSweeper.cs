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
        private BoardLogic boardLogic;
        TimeSpan timeSpan = new TimeSpan();
        bool gameOn = false;
        Button[,] buttons;

        public FrmMineSweeper(Board gameBoard)
        {
            InitializeComponent();
            board = gameBoard;
            buttons = new Button[board.Size, board.Size];
            boardLogic = new BoardLogic(board);
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
                    buttons[row, col].MouseDown += BtnCellMouseDownEH;
                    // Tag a point to each button
                    buttons[row, col].Tag = new Point(col, row);//col is x value, row is y value
                    // Add the buttons to the game panel
                    pnlGame.Controls.Add(buttons[row, col]);
                }
            }
        }

        /// <summary>
        /// Click event handler for buttons
        /// Soon as the first button is clicked, the game timer will start.
        /// tied to mouseclick 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCellMouseDownEH(object sender, MouseEventArgs e)
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
            int row = point.Y;
            int col = point.X;

            // Display choice to user (Testing purposes)
            //MessageBox.Show($"Cell {row},{col} has been selected");

            //if the click is a right mouseclick, flag or unflag the clicked cell
            if (e.Button == MouseButtons.Right)
            {
                if (board.Cells[row, col].IsFlagged)
                {
                    board.Cells[row, col].IsFlagged = false;
                }
                else
                {
                    board.Cells[row, col].IsFlagged = true;
                }
                UpdateButtons();
            }
            else if (!board.Cells[row, col].IsFlagged)
            {
                //call flood fill on cell if cell is empty
                if (board.Cells[row, col].NumberOfBombNeighbors < 1)
                {
                    board = boardLogic.FloodFill(board, row, col);
                }
                // Mark the cell as visited
                board.Cells[row, col].IsVisited = true;

                //give the player a use of the reward if found
                if (board.Cells[row, col].HasSpecialReward)
                {
                    board.RewardsRemaining++;
                }

                //After move is made, update the board
                UpdateButtons();

                // Determine if the game is over
                Board.GameStatus state = boardLogic.DetermineGameState();

                // If user won the game
                if (state == Board.GameStatus.Won)
                {
                    // Give celebratory message
                    MessageBox.Show("Congratulations! You've won the game!");

                    // Set gameOver to true, breaking gameplay loop
                    gameOn = false;
                }
                // If user lost the game
                else if (state == Board.GameStatus.Lost)
                {
                    // Give game over message
                    MessageBox.Show("Sorry, you hit a bomb. Game over!");

                    // Set gameOver to true, breaking gameplay loop
                    gameOn = false;
                }

                //When game is over, exit the application
                if (gameOn == false)
                {
                    Application.Exit();
                }
            }

        }

        /// <summary>
        /// Counts the time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrStopwatchTickEH(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// updates grid of buttons to refllect the board
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void UpdateButtons()
        {
            //walkthrough the grid of buttons, updating each one with the corresponding cells contents
            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    //set the contents of the button depending on what the corresponding cell if visited or flagged
                    if (board.Cells[row, col].IsVisited)
                    {
                        if (board.Cells[row, col].IsBomb)
                        {
                            buttons[row, col].Text = "B";
                        }
                        else if (board.Cells[row, col].HasSpecialReward)
                        {
                            buttons[row, col].Text = "R";
                            buttons[row, col].Enabled = false;
                        }
                        else if (board.Cells[row, col].NumberOfBombNeighbors > 0)
                        {
                            buttons[row, col].Text = "" + board.Cells[row, col].NumberOfBombNeighbors;
                            buttons[row, col].Enabled = false;
                        }
                        else
                        {
                            buttons[row, col].Enabled = false;
                        }
                        buttons[row, col].BackColor = Color.Gray;
                    }
                    else if (board.Cells[row, col].IsFlagged)
                    {
                        buttons[row, col].Text = "F";
                    }
                    //if cell isn't visited or flagged, leave it empty
                    else
                    {
                        buttons[row, col].Text = "";
                    }
                }
            }
            //update visibility of reward button if user has a reward to use.
            if (board.RewardsRemaining > 0)
            {
                btnUseReward.Visible = true;
            }
            else
            {
                btnUseReward.Visible = false;
            }
        }

        /// <summary>
        /// resets the board with new bomb placements
        /// </summary>
        private void ResetBoard()
        {
            //get the size and difficulty from the previous board to instantiate a new board
            int size = board.Size;
            int difficulty = board.Difficulty;
            board = new Board(size, difficulty);
            //instantiate a new boardLogic object with the new board
            //This will call the board setup methods again, "reseting" the board
            boardLogic = new BoardLogic(board);
            //re-enable all the buttons
            foreach (Button btn in pnlGame.Controls)
            {
                btn.Enabled = true;
                btn.Text = "";
            }
            //finally, update the board
            UpdateButtons();
        }

        /// <summary>
        /// Resets the board completely wiping the previous game and starting new
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRestartClickEH(object sender, EventArgs e)
        {
            ResetBoard();
        }

        /// <summary>
        /// event fires when the use reward button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUseRewardClickEH(object sender, EventArgs e)
        {
            //call the boardLogic's reward method
            boardLogic.UseSpecialBonus();
            //update the board once again
            UpdateButtons();
        }
    }
}
