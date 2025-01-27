using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperClasses
{
    public class Board
    {
        //Field Variables
        public int Size { get; set; }
        public int Difficulty { get; set; }
        public Cell[,] Cells { get; set; }
        public int RewardsRemaining { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public enum GameStatus { inProgress, Won, Lost }


        //Instantiations
        Random random = new Random();


        //Parameterized Constructor
        public Board(int size, int difficulty)
        {
            Size = size;
            Difficulty = difficulty;
            Cells = new Cell[size, size];
            RewardsRemaining = 0;
            InitializeBoard();
        }


        //Methods
        private void InitializeBoard()
        {
            SetupBombs();
            SetupRewards();
            CalculateNumberOfBombNeighbors();
            StartTime = DateTime.Now;
        }

        //used when player selects a cell and chooses to play the rewards(implement later)
        public void UseSpecialBonus()
        {

        }

        //use after game is over to calculate final score(Implemented later)
        public int DetermineFinalScore()
        {
            return 0;//placeholder
        }

        //helper function to determine if a cell is out of bounds
        private bool IsCellOnBoard(int row, int col)
        {
            if ((row >= 0 && row < Size) && (col >= 0 && col < Size))
                return true;
            else
                return false;
        }

        //use during setup to calculate the number of bomb nieghbors for each cell
        private void CalculateNumberOfBombNeighbors()
        {
            int rows = Cells.GetLength(0);
            int columns = Cells.GetLength(1);
            //walkthrough cells and count bombs for cells above, below, and to the side if they exist
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int bombCount = 0;
                    //cell is bomb
                    if (Cells[i, j].IsBomb)
                    {
                        bombCount = 9;
                        Cells[i, j].NumberOfBombNeighbors = 9;
                        continue;
                    }
                    //if the cell isn't a bomb, we're going to search the 8 surrounding cells and count the bombs in each using nested forloops
                    for (int iOffset = -1; iOffset <= 1; iOffset++)
                    {
                        for (int jOffset = -1; jOffset <= 1; jOffset++)
                        {
                            //exclude the cell itself
                            if (iOffset == 0 && jOffset == 0)
                            {
                                continue;
                            }
                            //now offset the current index and check if it's a bomb
                            int iCheck = i + iOffset;
                            int jCheck = j + jOffset;
                            if(IsCellOnBoard(iCheck, jCheck) && Cells[iCheck, jCheck].IsBomb)
                            {
                                bombCount++;
                            }
                        }
                    }
                    //set the bomb neighbors
                    Cells[i,j].NumberOfBombNeighbors = bombCount;
                }
            }
        }

        //use during setup to place bombs on the board
        private void SetupBombs()
        {
            //use difficulty to decide upper bound of random call when deciding bombs
            int bound = 1 + 10 / Difficulty;
            //get number of rows and columns

            int rows = Cells.GetLength(0);
            int columns = Cells.GetLength(1);

            //walkthrough every cell and set its row, column, and whether its a bomb or not
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int assignment = random.Next(1, bound);
                    //assign that array index with a cell at the given location
                    Cells[i, j] = new Cell();
                    Cells[i, j].Row = i;
                    Cells[i, j].Column = j;
                    if (assignment == 3)
                    {
                        Cells[i, j].IsBomb = true;
                    }
                }
            }
        }

        //use during setup to place rewards on the board
        private void SetupRewards()
        {
            //user has 1 use of the hint reward
            RewardsRemaining = 1;
        }

        //use every turn to determine the current game state(Implemented later)
        public GameStatus DetermineGameState()
        {
            return GameStatus.inProgress;//placeholder
        }
    }
}
