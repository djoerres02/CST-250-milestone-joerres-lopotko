/* Joseph Lopotko & Dylan Joerres
 * CST-250
 * Milestone 1
 * 1/26/25
 * Completed Together
 */
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperClasses.Models
{
    public class Board
    {
        // Field Variables
        public int Size { get; set; }
        public int Difficulty { get; set; }
        public Cell[,] Cells { get; set; }
        public int RewardsRemaining { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public enum GameStatus { InProgress, Won, Lost }


        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="size"></param>
        /// <param name="difficulty"></param>
        public Board(int size, int difficulty)
        {
            Size = size;
            Difficulty = difficulty;
            Cells = new Cell[size, size];
            RewardsRemaining = 0;
        }
    }
}
