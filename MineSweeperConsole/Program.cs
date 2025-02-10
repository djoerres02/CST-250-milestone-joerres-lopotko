﻿/* Joseph Lopotko & Dylan Joerres
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

        Board gameBoard = new Board(15, 3);

        // Bool variable for game over, allow for looping of game
        bool GameOver = false;

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
                // Toggle the flag status for the cell
                gameBoard.Cells[row, col].IsFlagged = !gameBoard.Cells[row, col].IsFlagged;
                Console.WriteLine(gameBoard.Cells[row, col].IsFlagged ? "Cell flagged." : "Cell unflagged.");
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
}