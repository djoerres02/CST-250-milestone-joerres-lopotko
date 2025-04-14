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
        // Class level variables
        private List<GameStat> _highScores;

        // Default file path to save score to
        private readonly string _defaultFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "Highscores.txt");


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
        /// Method to load highscores from a specified file
        /// </summary>
        /// <returns></returns>
        public string ReadHighScoresFromFile(string fileName)
        {
            // Declare and initialize
            _highScores = new List<GameStat>();

            // Check if the file exists before reading
            if (File.Exists(fileName))
            {
                try
                {
                    //store file lines in astring array
                    string[] lines = File.ReadAllLines(fileName);

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
                    // If the scores are read successfully, let the user know and update the IDs
                    UpdateIds();
                    return "Highscores loaded successfully.";
                }
                catch (Exception ex)
                {
                    // If the scores aren't read successfully, let the user know
                    return $"Error loading highscores: {ex.Message}";
                }
            }
            // If file isn't found, let the user know
            return "No highscore file found.";
        }

        /// <summary>
        /// Method that writes the highscores to the file
        /// </summary>
        /// <returns></returns>
        /// was a private specifier
        //public bool WriteHighScoresToFile()
        //{
        //    // Declare and initialize
        //    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
        //    string highScoreString = "";

        //    // Check if the directory exists
        //    if (!Directory.Exists(filePath))
        //    {
        //        // Create the directory
        //        Directory.CreateDirectory(filePath);
        //    }
        //    // Set up a try-catch for the file writer
        //    try
        //    {
        //        // Create a using statement for StreamWriter
        //        using (StreamWriter streamWriter = new StreamWriter(Path.Combine(filePath, "Highscores.txt")))
        //        {
        //            // Loop through the pizza order list
        //            foreach (GameStat highscore in _highScores)
        //            {
        //                highScoreString =
        //                    $"Name: {highscore.Name}, Score: {highscore.Score}, Time: {highscore.TimeSpan}";
        //                streamWriter.WriteLine(highScoreString);
        //            }
        //        }

        //        // Return true
        //        return true;
        //    }
        //    catch
        //    {
        //        // Return false
        //        return false;
        //    }
        //}


        /// <summary>
        /// Save highscores to a specified file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string WriteHighScoresToFile(string fileName)
        {
            try
            {
                // Use a StreamWriter object
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    // For each highscore
                    foreach (var highscore in _highScores)
                    {
                        // Initialize a line with the name, score, and timespan of the current highscore
                        string line = $"Name: {highscore.Name}, Score: {highscore.Score}, Time: {highscore.TimeSpan}";
                        // Write the line
                        writer.WriteLine(line);
                    }
                }
                // Return that the save was successful
                return $"Highscores saved successfully to {fileName}.";
            }
            catch (Exception ex)
            {
                // The save failed, let the user know.
                return $"Failed to save highscores to {fileName}: {ex.Message}";
            }
        }

        /// <summary>
        /// Overloaded method to save highscores to the default file
        /// </summary>
        /// <returns></returns>
        public string WriteHighScoresToFile()
        {
            return WriteHighScoresToFile(_defaultFilePath);
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

            //REMOVE LATER?
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
