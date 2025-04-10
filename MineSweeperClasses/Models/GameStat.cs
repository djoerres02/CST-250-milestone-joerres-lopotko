using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MineSweeperClasses.Models
{
    public class GameStat
    {
        private int id;
        private string name;
        private int score;
        private TimeSpan time;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <param name="Score"></param>
        /// <param name="Time"></param>
        public GameStat(int Id, string Name, int Score, TimeSpan Time)
        {
            id = Id;
            name = Name;
            score = Score;
            time = Time;
        }
    }
}
