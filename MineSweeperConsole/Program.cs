/* Joseph Lopotko & Dylan Joerres
 * CST-250
 * Milestone 1
 * 1/26/25
 * Completed Together
 */
using MineSweeperClasses.Models;
using MineSweeperClasses.Services.BusinessLogicLayer;
using System;

class Program
{
    //main method
    static void Main(string[] args)
    {
        // Print welcome message
        Console.WriteLine("Hello, welcome to Minesweeper!");

        // Answer key with 10x10 board with 1 difficulty
        Board board = new Board(10, 1);
        Console.WriteLine("Here is the answer key for the first board(1 difficulty):");
        PrintAnswerKey(board);

        // Answer key with 15x15 board with 3 difficulty
        board = new Board(15, 3);
        Console.WriteLine("\nHere is the answer key for the second board(3 difficulty):");
        PrintAnswerKey(board);

        // Create a new board for gameplay
        Board gameBoard = new Board(15, 3);

        // Instantiate gameLogic
        BoardLogic gameLogic = new BoardLogic(gameBoard);

        // Bool variable for game over, allow for looping of game
        bool GameOver = false;

        

        // Loop for running game
        while (!GameOver)
        {
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
                if (row < 0 || row >= board.Size)
                {
                    throw new ArgumentOutOfRangeException($"Row must be between 0 and {gameBoard.Size - 1}.");
                }
            }
            // Catch any invalid input
            catch (Exception ex)
            {
                // Inform user input is invalid, try again.
                Console.Write($"Invalid input: {ex.Message}. Please try again.");
                continue; // Restart prompt
            }


            // Try for valid column input
            try
            {
                // Ask user for column
                Console.WriteLine("Enter the column number:");
                // Record column input
                col = int.Parse(Console.ReadLine());
                // Check if column is in range
                if (col < 0 || col >= board.Size)
                {
                    // Inform user
                    throw new ArgumentOutOfRangeException(nameof(col), $"Column must be between 0 and {gameBoard.Size - 1}.");
                }
            }
            // Catch column exceptions
            catch (Exception ex)
            {
                // Inform user input is invalid, try again
                Console.WriteLine($"Invalid input: {ex.Message}. Please try again.");
                continue;  // Restart the loop
            }

            // Try for valid move input
            string moveType = "";
            try
            {
                // Prompt user for move type
                Console.WriteLine("Enter your move type: 'visit', 'flag', or 'use reward':");
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
                Console.WriteLine($"Invalid input: {ex.Message}. Please try again.");
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
                // Use special reward to peek at a cell
                if (gameBoard.RewardsRemaining > 0)
                {
                    // Inform user what cell is being peeked
                    Console.WriteLine($"Peeking at cell ({row}, {col}):");

                    // Get the cell to peek at
                    Cell peekCell = gameBoard.Cells[row, col];

                    // If cell is a bomb, display so accordingly
                    if (peekCell.IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("B (Bomb)");
                    }
                    // If cell has a reward, display reward
                    else if (peekCell.HasSpecialReward)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("R (Special Reward)");
                    }
                    // If cell has bomb neighbors, display how many
                    else if (peekCell.NumberOfBombNeighbors > 0)
                    {
                        // Choose color based on bomb neighbor count

                        // 1 bomb neighbor
                        if (peekCell.NumberOfBombNeighbors == 1)
                        {

                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        // 2 bomb neighbors
                        else if (peekCell.NumberOfBombNeighbors == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        // 3 bomb neighbors
                        else if (peekCell.NumberOfBombNeighbors == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        // 4 bomb neighbors
                        else if (peekCell.NumberOfBombNeighbors == 4)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        // 5 bomb neighbors
                        else if (peekCell.NumberOfBombNeighbors >= 5)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        }

                        // Print # of bomb neighbors
                        Console.WriteLine(peekCell.NumberOfBombNeighbors.ToString());
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("· (Empty)");
                    }

                    // Reset console color
                    Console.ResetColor();

                    // Use up reward
                        gameBoard.RewardsRemaining--;
                    

                }
                // No rewards, inform user to try again
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
    }


        //Print answer key board to console
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
    }
