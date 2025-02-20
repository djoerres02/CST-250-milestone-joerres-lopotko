/* Joseph Lopotko & Dylan Joerres
 * CST-250
 * Milestone 2
 * 1/26/25
 * Completed Together
 */
using MineSweeperClasses.Models;
using MineSweeperClasses.Services.BusinessLogicLayer;
using System;

// ----------------------------------------------------------------------------------------
// Main Method
// ----------------------------------------------------------------------------------------

// Print welcome message
Console.WriteLine("Hello, welcome to Minesweeper!");

// Create a new board for gameplay (Sized 4, difficulty 1)
Board gameBoard = new Board(5, 1);

PrintAnswerKey(gameBoard);

// Instantiate gameLogic
BoardLogic gameLogic = new BoardLogic(gameBoard);

// Bool variable for game over, allow for looping of game
// When GameOver is true, the game ends.
bool GameOver = false;

PrintBoard(gameBoard);

// ----------------------------------------------------------------------------------------
// End of Main Method
// ----------------------------------------------------------------------------------------

// Loop for running game, breaks when GameOver is set to true
// (Set True by game over, or win)
while (!GameOver)
{
    // Declare row and col
    int row;
    int col;

    // Try for valid row input
    try
    {
        // Ask user for row
        Console.Write("Enter the row number: ");
        // Record row input
        row = int.Parse(Console.ReadLine());
        // Check if row is in range
        if (row < 0 || row >= gameBoard.Size)
        {
            throw new ArgumentOutOfRangeException(nameof(col), $"Out of row range. ");
        }
    }
    // Catch any invalid input
    catch (Exception ex)
    {
        // Inform user input is invalid, try again.
        Console.Write($"Invalid input: {ex.Message} Input a valid integer for row from 0 and {gameBoard.Size - 1}: ");
        continue; // Restart the loop
    }


    // Try for valid column input
    try
    {
        // Ask user for column
        Console.Write("Enter the column number: ");
        // Record column input
        col = int.Parse(Console.ReadLine());
        // Check if column is in range
        if (col < 0 || col >= gameBoard.Size)
        {
            // Inform user
            throw new ArgumentOutOfRangeException(nameof(col), $"Out of column range. ");
        }
    }
    // Catch column exceptions
    catch (Exception ex)
    {
        // Inform user input is invalid, try again
        Console.Write($"Invalid input: {ex.Message} Input a valid integer for row from 0 and {gameBoard.Size - 1}: ");
        continue;  // Restart the loop
    }

    // Try for valid move input
    string moveType = "";
    try
    {
        // Prompt user for move type
        Console.Write("Enter your move type: 'visit', 'flag', or 'use reward': ");

        // Record move type, ensuring letters are converted to lowercase and white space is trimmed
        moveType = Console.ReadLine().Trim().ToLower();

        // Check if movetype matches visit, flag, or use reward
        if (moveType != "visit" && moveType != "flag" && moveType != "use reward")
        {
            // Inform user input is invalid, try again
            throw new ArgumentException("Move type must be 'visit', 'flag', or 'use reward'.");
        }

        // Process the move
        Console.WriteLine($"Move accepted: {moveType} at ({row}, {col}).");
    }
    // Catch movetype exceptions
    catch (Exception ex)
    {
        // Inform user input is invalid, try again
        Console.WriteLine($"Invalid input: {ex.Message}. Please select from move types 'visit', 'flag', or 'use reward': ");
        continue;
    }

    // Process the move based on the move type entered
    if (moveType == "visit")
    {
        // Check if the cell is already visited
        if (gameBoard.Cells[row, col].IsVisited)
        {
            Console.WriteLine("This cell has already been visited.");
        }
        // Check if cell is flagged
        else if (gameBoard.Cells[row, col].IsFlagged)
        {
            Console.WriteLine("This cell is flagged. Unflag it before visiting.");
        }
        // If it's not visited or flagged
        else
        {
            // Mark the cell as visited
            gameBoard.Cells[row, col].IsVisited = true;
            //give the player a use of the reward if found
            if (gameBoard.Cells[row, col].HasSpecialReward)
            {
                gameBoard.RewardsRemaining++;
            }
        }
    }
    // If moveType is a flag
    else if (moveType == "flag")
    {
        // Allow for enabling/disabling the flag status for the cell
        gameBoard.Cells[row, col].IsFlagged = !gameBoard.Cells[row, col].IsFlagged;
        // If flagging a flagged cell, unflag the cell
        Console.WriteLine(gameBoard.Cells[row, col].IsFlagged ? "Cell flagged." : "Cell unflagged.");
    }
    // If moveType is a reward
    else if (moveType == "use reward")
    {
        if (gameBoard.RewardsRemaining > 0)
        {
            gameLogic.UseSpecialBonus();
        }
        else
        {
            Console.WriteLine("No rewards, try again");
        }
    }

    // Determine if the game is over
    Board.GameStatus state = gameLogic.DetermineGameState();

    // If user won the game
    if (state == Board.GameStatus.Won)
    {
        // Give celebratory message
        Console.WriteLine("Congratulations! You've won the game!");

        // Set GameOver to true, breaking gameplay loop
        GameOver = true;
    }
    // If user lost the game
    else if (state == Board.GameStatus.Lost)
    {
        // Give game over message
        Console.WriteLine("Sorry, you hit a bomb. Game over!");

        // Set GameOver to true, breaking gameplay loop
        GameOver = true;
    }
    else
    {
        // Print the grid after each move
        PrintBoard(gameBoard);
    }
}


/// <summary>
/// Print the board without answers, used for gameplay
/// </summary>
/// <param name="board"></param>
static void PrintBoard(Board board)
{
    Cell[,] boardCells = board.Cells;
    int size = board.Size;

    // Print column numbers
    Console.Write("    ");
    for (int col = 0; col < size; col++)
    {
        Console.Write($"{col,2}  ");
    }
    Console.WriteLine();

    // Print the top line
    Console.Write("   ");
    for (int i = 0; i < size; i++)
    {
        Console.Write("+---");
    }
    Console.WriteLine("+");

    // To print the contents of the board during game play, we will loop through the cell list.
    // For unvisited cells (unless flagged), display a " " symbol.
    for (int row = 0; row < size; row++)
    {
        // Print row label number
        Console.Write($"{row,2} ");
        for (int col = 0; col < size; col++)
        {
            // Reset color before printing the vertical bar
            Console.ResetColor();
            Console.Write("| ");
            Cell cell = boardCells[row, col];
            string cellContent = "";

            if (!cell.IsVisited)
            {
                // If the cell is flagged, display "F"
                if (cell.IsFlagged)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    cellContent = "F";
                }
                else
                {
                    // Otherwise display " "
                    Console.ForegroundColor = ConsoleColor.Gray;
                    cellContent = " ";
                }
            }
            else // Cell is visited, so show its actual content
            {
                // If cell is bomb
                if (cell.IsBomb)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    cellContent = "B";
                }

                // If cell has a reward
                else if (cell.HasSpecialReward)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    cellContent = "R";
                }

                // If cell has 2 bomb neighbors
                else if (cell.NumberOfBombNeighbors == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    cellContent = cell.NumberOfBombNeighbors.ToString();
                }

                // If cell has 2 bomb neighbors
                else if (cell.NumberOfBombNeighbors == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    cellContent = cell.NumberOfBombNeighbors.ToString();
                }

                // If a cell has 3 bomb neighbors
                else if (cell.NumberOfBombNeighbors == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    cellContent = cell.NumberOfBombNeighbors.ToString();
                }

                // If a cell has 4 bomb neighbors
                else if (cell.NumberOfBombNeighbors == 4)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    cellContent = cell.NumberOfBombNeighbors.ToString();
                }

                // If a cell has greater than or equal to 5 bomb neighbors
                else if (cell.NumberOfBombNeighbors >= 5)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    cellContent = cell.NumberOfBombNeighbors.ToString();
                }

                // If a cell has no bomb neighbors
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    cellContent = "·";
                }
            }
            // Print the cell content with spacing of 1 character
            Console.Write($"{cellContent,1} ");
        }
        // Reset color and print the final vertical border for the row
        Console.ResetColor();
        Console.WriteLine("|");

        // Print the horizontal line below the row
        Console.Write("   ");
        for (int i = 0; i < size; i++)
        {
            Console.Write("+---");
        }
        Console.WriteLine("+");
    }
}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// Below is code for printing the answer key , not used in Milestone 2
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------

/// <summary>
/// Print answer key for a board
/// </summary>
/// <param name="board"></param>
static void PrintAnswerKey(Board board)
{

    BoardLogic boardLogic = new BoardLogic(board);
    Cell[,] boardCells = boardLogic.board.Cells;
    int size = board.Size;

    // Print column numbers
    Console.Write("    ");
    for (int col = 0; col < size; col++)
    {
        Console.Write($"{col,2}  "); // {col,2} allows for better spacing
    }
    Console.WriteLine();

    // Print the top line
    Console.Write("   ");
    for (int i = 0; i < size; i++)
    {
        Console.Write("+---");
    }
    Console.WriteLine("+");

    // To print the contents of the board, we will loop through the cell list writing the contents of the cells in a row before skipping to a new line
    for (int row = 0; row < size; row++)
    {
        // Print row label number
        Console.Write($"{row,2} "); // Allows numbers to be lined up

        for (int col = 0; col < size; col++)
        {
            // Reset color before printing the vertical bar to ensure it is not colored
            Console.ResetColor();
            Console.Write("| ");

            // Determine and display the content of each cell
            string cellContent;
            if (boardCells[row, col].IsBomb)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                cellContent = "B"; // Bomb cell
            }
            // Print 1 bomb count in cyan
            else if (boardCells[row, col].NumberOfBombNeighbors == 1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                cellContent = boardCells[row, col].NumberOfBombNeighbors.ToString();
            }
            // Print 2 bomb count in green
            else if (boardCells[row, col].NumberOfBombNeighbors == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                cellContent = boardCells[row, col].NumberOfBombNeighbors.ToString();
            }
            // Print 3 bomb count in magenta
            else if (boardCells[row, col].NumberOfBombNeighbors == 3)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                cellContent = boardCells[row, col].NumberOfBombNeighbors.ToString();
            }
            // Print 4 bomb count in dark yellow
            else if (boardCells[row, col].NumberOfBombNeighbors == 4)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                cellContent = boardCells[row, col].NumberOfBombNeighbors.ToString();
            }
            // Print 5 or more bomb count in dark magenta
            else if (boardCells[row, col].NumberOfBombNeighbors >= 5)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                cellContent = boardCells[row, col].NumberOfBombNeighbors.ToString();
            }
            // Print empty cells in white
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                cellContent = "·"; // Empty cell indicator
            }

            // Print the cell content
            Console.Write($"{cellContent,1} ");
        }

        // Reset color and print the final vertical border for the row
        Console.ResetColor();
        Console.WriteLine("|");

        // Print the horizontal line below the row
        Console.Write("   ");
        for (int i = 0; i < size; i++)
        {
            Console.Write("+---");
        }
        Console.WriteLine("+");
    }
}

