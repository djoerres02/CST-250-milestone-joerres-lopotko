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
        private List<GameStat> _highScores;

        /// <summary>
        /// default constructor
        /// </summary>
        public BoardDAO()
        {
            //load the highscores as soon as the program is run
            LoadHighScores();
        }

        /// <summary>
        /// Method that reads the highscores from a file and stores the
        /// parsed highscore objects in the DAOs highscores list
        /// </summary>
        public void LoadHighScores()
        {
            // Declare and initialize
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "Highscores.txt");
            _highScores = new List<GameStat>();

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
                            if (parts.Length == 3)
                            {
                                //trim the name labels
                                string namePart = parts[0].Replace("Name: ", "").Trim();

                                //trim the score labels
                                string scorePart = parts[1].Replace("Score: ", "").Trim();

                                //trim the timespan labels
                                string timespanPart = parts[2].Replace("Time: ", "").Trim();

                                //try to parse the score
                                if (int.TryParse(scorePart, out int score) && TimeSpan.TryParse(timespanPart, out TimeSpan timespan))
                                {
                                    //add score to list
                                    _highScores.Add(new GameStat(namePart, score, timespan));
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
            //make sure the ids are correct
            UpdateIds();
        }

        /// <summary>
        /// Method that writes the highscores to the file
        /// </summary>
        /// <returns></returns>
        private bool WriteHighScoresToFile()
        {
            // Declare and initialize
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
            string highScoreString = "";

            // Check if the directory exists
            if (!Directory.Exists(filePath))
            {
                // Create the directory
                Directory.CreateDirectory(filePath);
            }
            // Set up a try-catch for the file writer
            try
            {
                // Create a using statement for StreamWriter
                using (StreamWriter streamWriter = new StreamWriter(Path.Combine(filePath, "Highscores.txt")))
                {
                    // Loop through the pizza order list
                    foreach (GameStat highscore in _highScores)
                    {
                        highScoreString =
                            $"Name: {highscore.Name}, Score: {highscore.Score}, Time: {highscore.TimeSpan}";
                        streamWriter.WriteLine(highScoreString);
                    }
                }

                // Return true
                return true;
            }
            catch
            {
                // Return false
                return false;
            }

        }

        /// <summary>
        /// Adds a highscore to the list of highscores and trims it to a maximum of 5 scores
        /// </summary>
        /// <param name="highScore"></param>
        /// <returns></returns>
        public int AddToHighScores(GameStat highScore)
        {
            // Add the new score to the list
            _highScores.Add(highScore);

            // Sort the list in descending order by score
            _highScores = _highScores.OrderByDescending(s => s.Score).ToList();

            //update the ids
            UpdateIds();

            //write highscores to file
            WriteHighScoresToFile();
            
            //return index of new highscore
            return _highScores.Count;
        }

        /// <summary>
        /// Updates the ids so that they are accurate
        /// </summary>
        public void UpdateIds()
        {
            //loop through list
            for (int i = 0; i < _highScores.Count; i++)
            {
                {
                    //set the id of each score
                    _highScores[i].Id = i + 1;
                }
            }
        }

        /// <summary>
        /// returns the list of highscores
        /// </summary>
        /// <returns></returns>
        public List<GameStat> GetHighScores()
        {
            return _highScores;
        }
    }
}
