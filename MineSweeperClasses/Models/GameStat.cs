using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperClasses.Models
{
    public class GameStat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public TimeSpan TimeSpan { get; set; }

        public GameStat(string name,  int score, TimeSpan timeSpan)
        {
            Name = name;
            Score = score;
            TimeSpan = timeSpan;
            Id = 0;
        }
    }
}
