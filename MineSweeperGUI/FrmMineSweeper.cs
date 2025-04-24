/* 
 * Joseph Lopotko & Dylan Joerres
 * CST-250
 * Milestone 4
 * 2/26/2025
 * Completed Together
 * Used TimeSpan code from Activity 5
 * Used code to populate buttons from Activity 2
 * Inserted minesweeper images to project via resource file ResourceImages.resx (https://youtu.be/rN807Rk8UoI)
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
        // TimeSpan object to track time
        TimeSpan timeSpan = new TimeSpan();
        // Boolean to indicate the game is running
        bool gameOn = false;
        // 2D array to store button references
        Button[,] buttons;
        // Initialize gameScore to keep track of user's score
        int gameScore = 0;

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
            //start background music
            boardLogic.PlayBackgroundMusic(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Audio", "music1.mp3"));
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
                    // Set button background properties
                    buttons[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                    // Set default button background
                    buttons[row, col].BackgroundImage = ResourceImages.Tile2;
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
                tmrStopWatch.Start();
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
                    // Unflag the cell
                    board.Cells[row, col].IsFlagged = false;
                    // Reset the background image of the cell
                    buttons[row, col].BackgroundImage = ResourceImages.Tile2;
                }
                else
                {
                    // Play flag sound effect
                    boardLogic.PlayAudio(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Audio", "flag.mp3"));
                    // Flag the cell
                    board.Cells[row, col].IsFlagged = true;
                    // Set the background image of the cell to be the flag
                    buttons[row, col].BackgroundImage = ResourceImages.Flag;
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

                // Play visit sound effect
                boardLogic.PlayAudio(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Audio", "visitcell.mp3"));

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
                    // Stop the timer
                    tmrStopWatch.Stop();
                    // Give celebratory message
                    MessageBox.Show("Congratulations! You've won the game!");
                    // Set gameOver to true
                    gameOn = false;
                    // Ensure user can no longer interact with the board
                    pnlGame.Enabled = false;
                    // Prompt user to submit score
                    FrmSubmitScore frmSubmitScore = new FrmSubmitScore(gameScore, timeSpan, boardLogic);
                    frmSubmitScore.Show();
                }
                // If user lost the game
                else if (state == Board.GameStatus.Lost)
                {
                    // Stop the timer
                    tmrStopWatch.Stop();
                    // Play explosion audio
                    boardLogic.PlayAudio(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Audio", "explosion.mp3"));
                    // Give game over message
                    MessageBox.Show("Sorry, you hit a bomb. Game over!");
                    // Set gameOver to true
                    gameOn = false;
                    // Ensure user can no longer interact with the board
                    pnlGame.Enabled = false;
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
            if (gameOn)
            {
                timeSpan = timeSpan.Add(TimeSpan.FromMilliseconds(tmrStopWatch.Interval));
                lblTime.Text = timeSpan.ToString();
            }
        }

        /// <summary>
        /// Updates grid of buttons to reflect the board
        /// also update the game score
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
                        // Set background to a flat tile indicating it's visited
                        buttons[row, col].BackgroundImage = ResourceImages.TileFlat;
                        if (board.Cells[row, col].IsBomb)
                        {
                            // Set background to a skull indicating it's a bomb
                            buttons[row, col].BackgroundImage = ResourceImages.Skull;
                        }
                        else if (board.Cells[row, col].HasSpecialReward)
                        {
                            // Set background to gold indicating it's a reward
                            buttons[row, col].BackgroundImage = ResourceImages.Gold;
                            // Disable the button
                            buttons[row, col].Enabled = false;
                        }
                        else if (board.Cells[row, col].NumberOfBombNeighbors > 0)
                        {
                            // Disable the button so the user can't interact with it
                            buttons[row, col].Enabled = false;
                            // Add to the score based off of the number of bomb neighbors
                            gameScore += board.Cells[row, col].NumberOfBombNeighbors;
                            // Switch statement
                            // Based on # of bomb neighbors, set the background image according to the number
                            // Also add to the point counter
                            switch (board.Cells[row, col].NumberOfBombNeighbors)
                            {
                                case 1:
                                    buttons[row, col].BackgroundImage = ResourceImages.Number1;
                                    break;
                                case 2:
                                    buttons[row, col].BackgroundImage = ResourceImages.Number2;
                                    break;
                                case 3:
                                    buttons[row, col].BackgroundImage = ResourceImages.Number3;
                                    break;
                                case 4:
                                    buttons[row, col].BackgroundImage = ResourceImages.Number4;
                                    break;
                                case 5:
                                    buttons[row, col].BackgroundImage = ResourceImages.Number5;
                                    break;
                                case 6:
                                    buttons[row, col].BackgroundImage = ResourceImages.Number6;
                                    break;
                                case 7:
                                    buttons[row, col].BackgroundImage = ResourceImages.Number7;
                                    break;
                                default:
                                    buttons[row, col].BackgroundImage = ResourceImages.Number8;
                                    break;
                            }
                            // Update the score label
                            lblScore.Text = gameScore.ToString();
                        }
                        // If button has no neighbors, disable it
                        else
                        {
                            buttons[row, col].Enabled = false;
                        }
                    }
                    // If cell is flagged, set it's background to represent a flag
                    else if (board.Cells[row, col].IsFlagged)
                    {
                        buttons[row, col].BackgroundImage = ResourceImages.Flag;
                    }
                    //if cell isn't visited or flagged, leave it empty
                    else
                    {
                        buttons[row, col].Text = "";
                    }
                }
            }
            // Update visibility of reward button if user has a reward to use.
            if (board.RewardsRemaining > 0)
            {
                btnUseReward.Visible = true;
            }
            // If no reward is available, hide the button
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
            // Stop the music, preventing duplicate music
            boardLogic.StopMusic();
            // Ensure time is stopped
            tmrStopWatch.Stop();
            // Ensure gameOn is set to false, so we can correctly start the timer
            // when the user clicks a button
            gameOn = false;

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
                // Reset background image
                btn.BackgroundImage = ResourceImages.Tile2;
            }
            // Enable the panel the boards are on
            // allow for user input again
            pnlGame.Enabled = true;
            // Reset the score
            gameScore = 0;
            // Update the score label
            lblScore.Text = gameScore.ToString();
            // Reset the timer
            timeSpan = TimeSpan.Zero;
            // Update the timer label
            lblTime.Text = timeSpan.ToString();
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

        /// <summary>
        /// Button to exit the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExitClickEH(object sender, EventArgs e)
        {
            // Close the game form
            this.Close();
        }

        /// <summary>
        /// Checked Changed EH for changing music
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbnMusicCheckedChangedEH(object sender, EventArgs e)
        {
            // Ensure music is stopped
            boardLogic.StopMusic();

            // If statement checking for the sender type and if the radio button sender is checked
            if (sender is RadioButton radioButton && radioButton.Checked)
            {
                // Switch statement based off of radio button name
                // Plays the respective music
                switch (radioButton.Name)
                {
                    case "rbnMusic1":
                        boardLogic.PlayBackgroundMusic(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Audio", "music1.mp3"));
                        break;
                    case "rbnMusic2":
                        boardLogic.PlayBackgroundMusic(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Audio", "music2.mp3"));
                        break;
                    case "rbnMusic3":
                        boardLogic.PlayBackgroundMusic(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Audio", "music3.mp3"));
                        break;
                    default:
                        // Assume rbnMusicOff is selected, music is already stopped above
                        break;
                }
            }
        }
    }
}
