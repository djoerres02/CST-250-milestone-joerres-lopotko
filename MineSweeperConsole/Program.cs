﻿using MineSweeperClasses;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, welcome to Minesweeper!");

        // answer key with 10x10 board with 1 diffculty
        Board board = new Board(10, 1);
        Console.WriteLine("Here is the answer key for the first board(1 difficulty):");
        PrintAnswerKey(board);

        // answer key with 15x15 board
        board = new Board(15, 3); // Difficulty adjusted for integer handling
        Console.WriteLine("\nHere is the answer key for the second board(3 difficulty):");
        PrintAnswerKey(board);
    }

    static void PrintAnswerKey(Board board)
    {
        Cell[,] boardCells = board.Cells;
        int size = board.Size;

        // Print column numbers
        Console.Write("    ");
        for (int col = 0; col < size; col++)
        {
            Console.Write($"{col,3}"); // {col,3} allows for numbers to be more evenly spaced
        }
        Console.WriteLine();

        // Print top line
        Console.Write("----");
        for (int i = 0; i < size*3; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();

        //now to print the contents of the board we will loop through the cell list writing the contents of the cells in a row before skipping to new line
        for (int row = 0; row < size; row++)
        {
            // Print row label number
            Console.Write($"{row,3}|"); // allows numbers to be lined up

            for (int col = 0; col < size; col++)
            {
                // Display the content of each cell
                // print bomb in red
                if (boardCells[row, col].IsBomb)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{"B",3}");
                }
                // print 1 bomb count in cyan
                else if (boardCells[row, col].NumberOfBombNeighbors == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan; 
                    Console.Write($"{boardCells[row, col].NumberOfBombNeighbors,3}");
                }
                // print 2 bomb count in green
                else if (boardCells[row, col].NumberOfBombNeighbors == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{boardCells[row, col].NumberOfBombNeighbors,3}");
                }
                //print 3 bomb count in magenta
                else if (boardCells[row, col].NumberOfBombNeighbors == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"{boardCells[row, col].NumberOfBombNeighbors,3}");
                }
                //print 4 bomb count in dark yellow
                else if (boardCells[row, col].NumberOfBombNeighbors == 4)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"{boardCells[row, col].NumberOfBombNeighbors,3}");
                }
                //print 5 bomb count in dark magenta
                else if (boardCells[row, col].NumberOfBombNeighbors >= 5)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write($"{boardCells[row, col].NumberOfBombNeighbors,3}");
                }
                //print empty cells in white
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{"·",3}");
                }

                // Reset color
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        // Print bottom line
        Console.Write("----");
        for (int i = 0; i < size * 3; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
    }
}