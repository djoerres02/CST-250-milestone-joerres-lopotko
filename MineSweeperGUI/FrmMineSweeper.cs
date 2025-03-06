/* 
 * Joseph Lopotko & Dylan Joerres
 * CST-250
 * Milestone 4
 * 2/26/2025
 * Completed Together
 */
using MineSweeperClasses.Models;

namespace MineSweeperGUI
{
    public partial class FrmMineSweeper : Form
    {
        private Board board;
        public FrmMineSweeper(Board gameBoard)
        {
            InitializeComponent();
            board = gameBoard;
        }
    }
}
