using Hangman2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hangman2.Utility
{
    public static class FileReader
    {
        private const string ANIMALS_PATH = "D:/Proiecte/Hangman-Spanzuratoarea/Hangman2/Hangman2/Files/Category/Animals.txt";
        private const string BIOLOGY_PATH = "D:/Proiecte/Hangman-Spanzuratoarea/Hangman2/Hangman2/Files/Category/Biology.txt";
        private const string CARS_PATH = "D:/Proiecte/Hangman-Spanzuratoarea/Hangman2/Hangman2/Files/Category/Cars.txt";
        private const string COMPUTER_SCIENCE_PATH = "D:/Proiecte/Hangman-Spanzuratoarea/Hangman2/Hangman2/Files/Category/Computer Science.txt";
        private const string FRUITS_PATH = "D:/Proiecte/Hangman-Spanzuratoarea/Hangman2/Hangman2/Files/Category/FruitsAndVegetables.txt";
        private const string MOUNTAINS_PATH = "D:/Proiecte/Hangman-Spanzuratoarea/Hangman2/Hangman2/Files/Category/Mountains.txt";
        private const string MOVIES_PATH = "D:/Proiecte/Hangman-Spanzuratoarea/Hangman2/Hangman2/Files/Category/Movies.txt";
        private const string RIVERS_PATH = "D:/Proiecte/Hangman-Spanzuratoarea/Hangman2/Hangman2/Files/Category/Rivers.txt";
        private const string USERS_PATH = "D:/Proiecte/Hangman-Spanzuratoarea/Sources/users.txt";
        private const string PICS_PATH = "D:/Proiecte/Hangman-Spanzuratoarea/Sources/picsPath.txt";

        public static List<string> ReadWords(string opt)
        {
            List<string>? result = new List<string>();
            switch (opt)
            {
                case "Fruit":
                    {
                        result.Clear();
                        foreach (var line in System.IO.File.ReadLines(FRUITS_PATH))
                        {
                            result.Add(line);
                        }
                        return result;
                    }
                case "Animal":
                    {
                        result.Clear();
                        foreach (var line in System.IO.File.ReadLines(ANIMALS_PATH))
                        {
                            result.Add(line);
                        }
                        return result;
                    }
                case "Biology":
                    {
                        result.Clear();
                        foreach (var line in System.IO.File.ReadLines(BIOLOGY_PATH))
                        {
                            result.Add(line);
                        }
                        return result;
                    }
                case "Car":
                    {
                        result.Clear();
                        foreach (var line in System.IO.File.ReadLines(CARS_PATH))
                        {
                            result.Add(line);
                        }
                        return result;
                    }
                case "Computer":
                    {
                        result.Clear();
                        foreach (var line in System.IO.File.ReadLines(COMPUTER_SCIENCE_PATH))
                        {
                            result.Add(line);
                        }
                        return result;
                    }
                case "Mountains":
                    {
                        result.Clear();
                        foreach (var line in System.IO.File.ReadLines(MOUNTAINS_PATH))
                        {
                            result.Add(line);
                        }
                        return result;
                    }
                case "Movies":
                    {
                        {
                            result.Clear();
                            foreach (var line in System.IO.File.ReadLines(MOVIES_PATH))
                            {
                                result.Add(line);
                            }
                            return result;
                        }
                    }
                case "Rivers":
                    {
                        result.Clear();
                        foreach (var line in System.IO.File.ReadLines(RIVERS_PATH))
                        {
                            result.Add(line);
                        }
                        return result;
                    }

                default:
                    return null;
            }
        }

        public static List<User> ReadUsers()
        {
            var result = new List<User>();
            using (Stream stream = new FileStream(USERS_PATH, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                if (File.Exists(USERS_PATH) && stream.Length > 0)
                {
                    // read the entire file using a `StreamReader`
                    string fileContents;
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        fileContents = reader.ReadToEnd();
                    }
                    // deserialize the contents of the file
                    result = JsonSerializer.Deserialize<List<User>>(fileContents);
                    return result;
                }

            }
            return result;
        }

        public static List<string> ReadPicsPath()
        {
            var result = new List<string>();
            foreach (var line in System.IO.File.ReadLines(PICS_PATH))
            {
                result.Add(line);
            }
            return result;
        }
    }
}
