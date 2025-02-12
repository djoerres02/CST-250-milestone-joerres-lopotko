using MineSweeperClasses.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static MineSweeperClasses.Models.Board;

namespace MineSweeperClasses.Services.BusinessLogicLayer
{
    public class BoardLogic
    {
        //Field Variables
        public Board board { get; set; }

        public BoardLogic(Board board)
        {
            this.board = board;
            InitializeBoard();
        }

        // Instantiate random
        Random random = new Random();

        /// <summary>
        /// Initialize the board
        /// </summary>
        private void InitializeBoard()
        {
            // Call Methods
            SetupBombs();
            SetupRewards();
            CalculateNumberOfBombNeighbors();
            board.StartTime = DateTime.Now;
        }

        /// <summary>
        /// Used when player selects a cell and chooses to play the rewards(implement later)
        /// </summary>
        public void UseSpecialBonus()
        {
            board.RewardsRemaining = 0;
            int rows = board.Cells.GetLength(0);
            int columns = board.Cells.GetLength(1);
            //walkthrough cells and if a bomb has a visited neighbor, flag it
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (board.Cells[i, j].IsBomb) //check neighbors if cell is bomb
                    {
                        //create two arrays that will hold values that will be added to the bombs row and collumn to access it's neighbprs
                        int[] offsetCol = { 0, 1, 1, 1, 0, -1, -1, -1 };
                        int[] offsetRow = { -1, -1, 0, 1, 1, 1, 0, -1 };

                        //walkthrough all cells
                        for (int k = 0; k < offsetCol.Length; k++)
                        {
                            if ((board.Cells[i + offsetRow[k], j + offsetCol[k]].IsVisited) && (board.Cells[i + offsetRow[k], j + offsetCol[k]].IsBomb == false))//checks if the current neighbor cell is visited
                            {
                                board.Cells[i, j].IsFlagged = true;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Use after game is over to calculate final score(Implemented later)
        /// </summary>
        /// <returns></returns>
        public int DetermineFinalScore()
        {
            return 0;//placeholder
        }

        /// <summary>
        /// Helper function to determine if a cell is out of bounds
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private bool IsCellOnBoard(int row, int col)
        {
            if (row >= 0 && row < board.Size && col >= 0 && col < board.Size)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Use during setup to calculate the number of bomb nieghbors for each cell
        /// </summary>
        private void CalculateNumberOfBombNeighbors()
        {
            int rows = board.Cells.GetLength(0);
            int columns = board.Cells.GetLength(1);
            // Walkthrough cells and count bombs for cells above, below, and to the side if they exist
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int bombCount = 0;
                    // Cell is bomb
                    if (board.Cells[i, j].IsBomb)
                    {
                        bombCount = 9;
                        board.Cells[i, j].NumberOfBombNeighbors = 9;
                        continue;
                    }
                    // If the cell isn't a bomb, we're going to search the 8 surrounding cells and count the bombs in each using nested forloops
                    for (int iOffset = -1; iOffset <= 1; iOffset++)
                    {
                        for (int jOffset = -1; jOffset <= 1; jOffset++)
                        {
                            // Exclude the cell itself
                            if (iOffset == 0 && jOffset == 0)
                            {
                                continue;
                            }
                            // Now offset the current index and check if it's a bomb
                            int iCheck = i + iOffset;
                            int jCheck = j + jOffset;
                            if (IsCellOnBoard(iCheck, jCheck) && board.Cells[iCheck, jCheck].IsBomb)
                            {
                                bombCount++;
                            }
                        }
                    }
                    // Set the bomb neighbors
                    board.Cells[i, j].NumberOfBombNeighbors = bombCount;
                }
            }
        }

        /// <summary>
        /// Use during setup to place bombs on the board
        /// </summary>
        private void SetupBombs()
        {
            // Use difficulty to decide upper bound of random call when deciding bombs
            int bound = 1 + 10 / board.Difficulty;
            // Get number of rows and columns

            int rows = board.Cells.GetLength(0);
            int columns = board.Cells.GetLength(1);

            // Walkthrough every cell and set its row, column, and whether its a bomb or not
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int assignment = random.Next(1, bound);
                    // Assign that array index with a cell at the given location
                    board.Cells[i, j] = new Cell();
                    board.Cells[i, j].Row = i;
                    board.Cells[i, j].Column = j;
                    if (assignment == 3)
                    {
                        board.Cells[i, j].IsBomb = true;
                    }
                }
            }
        }

        /// <summary>
        /// Use during setup to place rewards on the board
        /// </summary>
        private void SetupRewards()
        {
            // User has 1 use of the hint reward
            board.RewardsRemaining = 1;
            int row = random.Next(board.Size);
            int col = random.Next(board.Size);

            board.Cells[row, col].HasSpecialReward = true;
        }

        /// <summary>
        /// Use every turn to determine the current game state(Implemented later)
        /// </summary>
        /// <returns></returns>
        public GameStatus DetermineGameState()
        {
            //Check for win
            Boolean isWin = true;
            //walkthrough each cell and return loss if bomb cell is visited
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    if (board.Cells[i, j].IsBomb && board.Cells[i, j].IsVisited)//check for loss
                    {
                        return GameStatus.Lost;
                    }
                    if ((board.Cells[i, j].IsBomb == false) && (board.Cells[i, j].IsVisited == false))//if none of the cells trigger this if, they've won the game.
                    {
                        isWin = false;
                    }
                }
            }
            if (isWin)
            {
                return GameStatus.Won;
            }
            //otherwise keep playing
            else
            {
                return GameStatus.InProgress;
            }
        }
    }
}
