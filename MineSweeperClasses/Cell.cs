/* Joseph Lopotko & Dylan Joerres
 * CST-250
 * Milestone 1
 * 1/26/25
 * Completed Together
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperClasses
{
    public class Cell
    {
        //Field Variables
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsVisited { get; set; }
        public bool IsBomb { get; set; }
        public bool IsFlagged { get; set; }
        public int NumberOfBombNeighbors { get; set; }
        public bool HasSpecialReward { get; set; } // Use hint ability


        /// <summary>
        /// Default Constructor
        /// </summary>
        public Cell()
        {
            Row = -1;
            Column = -1;
            IsVisited = false;
            IsBomb = false;
            IsFlagged = false;
            HasSpecialReward = false;
        }
    }
}