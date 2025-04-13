using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineSweeperClasses.Models;
using MineSweeperClasses.Services.DataAccessLayer;

namespace MineSweeperClasses.Services.BusinessLogicLayer
{
    public class ScoreLogic
    {
        // Instantiate boardDAO
        BoardDAO _boardDAO = new BoardDAO();

        /// <summary>
        /// creates a gamestat object using passed values and passes it to the dao
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public int AddHighScore(string name, int score, TimeSpan timeSpan)
        {
            //create a gamestat object with the given values and pass it to the DAO
            return _boardDAO.AddToHighScores(new GameStat(name, score, timeSpan));
        }

        /// <summary>
        /// returns a list of highscores
        /// </summary>
        /// <returns></returns>
        public List<GameStat> GetHighScores()
        {
            return _boardDAO.GetHighScores();
        }

    }
}
