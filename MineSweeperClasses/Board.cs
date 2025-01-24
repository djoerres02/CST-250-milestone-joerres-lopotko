using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperClasses
{
    public class Board
    {
        //Field Variables
        public int Size { get; set; }
        public float Difficulty { get; set; }
        public Cell[,] Cells { get; set; }
        public int  RewardsRemaining { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public enum GameStatus { inProgress, Won, Lost}


        //Instantiations
        Random random = new Random();


        //Parameterized Constructor
        public Board(int size, float difficulty) {
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

        //used when player selects a cell and chooses to play the rewards
        public void UseSpecialBonus()
        {

        }

        //use after game is over to calculate final score
        public int DetermineFinalScore()
        {
            return 0;//placeholder
        }

        //helper function to dtermine if a cell is out of bounds
        private bool IsCellOnBoard(int row, int col)
        {
            return false;//placeholder
        }

        //use during setup to calculate the number of bomb nieghbors for each cell
        private void CalculateNumberOfBombNeighbors()
        {

        }

        //use during setup to place bombs on the board
        private void SetupBombs()
        {

        }

        //use during setup to place rewards on the board
        private void SetupRewards()
        {

        }

        //use every turn to determine the current game state
        public GameStatus DetermineGameState()
        {
            return GameStatus.inProgress;//placeholder
        }
    }
}
