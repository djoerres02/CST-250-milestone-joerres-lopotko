using MineSweeperClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperClasses.Services.DataAccessLayer
{
    internal class BoardDAO
    {
        //class level variables
        private List<GameStat> highScores;

        /// <summary>
        /// Method that reads the highscores from a file and stores the
        /// parsed highscore objects in the DAOs highscores list
        /// </summary>
        public void LoadHighScores()
        {
            // Declare and initialize
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "Highscores.txt");
            List<GameStat> highScores = new List<GameStat>();

            // Check if the file exists before reading
            if (File.Exists(filePath))
            {
                try
                {
                    //store file lines in astring array
                    string[] lines = File.ReadAllLines(filePath);

                    //loop through the lines and parse the scores
                    foreach (string line in lines)
                    {
                        //check for empty line
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            //split the line based on comma
                            string[] parts = line.Split(',');

                            // Check if we have both name and score
                            if (parts.Length == 2)
                            {
                                //trim the name labels
                                string namePart = parts[0].Replace("Name: ", "").Trim();

                                //trim the score labels
                                string scorePart = parts[1].Replace("Score: ", "").Trim();

                                //try to parse the score
                                if (int.TryParse(scorePart, out int score))
                                {
                                    //add score to list
                                    highScores.Add(new GameStat(namePart, score));
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading highscores: {ex.Message}");
                }
            }
        }
}
