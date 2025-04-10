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
        private DateTime date;

        public GameStat(int Id, string Name, int Score, DateTime Date)
        {
            id = Id;
            name = Name;
            score = Score;
            date = Date;
        }
    }
}
