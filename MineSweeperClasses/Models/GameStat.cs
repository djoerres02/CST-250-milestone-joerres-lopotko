using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
/* 
 * Joseph Lopotko & Dylan Joerres
 * CST-250
 * Milestone 4
 * 4/06/2025
 * Completed Together
 * Used TimeSpan code from Activity 5
 * Used code from Activity 6 for file dialog
 */
namespace MineSweeperClasses.Models
{
    public class GameStat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public TimeSpan TimeSpan { get; set; }

        /// <summary>
        /// paramterized constructor for GameStat class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        /// <param name="timeSpan"></param>
        public GameStat(string name,  int score, TimeSpan timeSpan)
        {
            Name = name;
            Score = score;
            TimeSpan = timeSpan;
            Id = 0;
        }
    }
}
