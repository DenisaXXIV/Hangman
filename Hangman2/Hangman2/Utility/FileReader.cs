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
        private const string WORDS_PATH = "D:/Proiecte/Hangman-Spanzuratoarea/Sources/words.txt";
        private const string USERS_PATH = "D:/Proiecte/Hangman-Spanzuratoarea/Sources/users.txt";
        private const string PICS_PATH = "D:/Proiecte/Hangman-Spanzuratoarea/Sources/picsPath.txt";

        public static List<string> ReadWords()
        {
            var result = new List<string>();
            foreach (var line in System.IO.File.ReadLines(WORDS_PATH))
            {
                result.Add(line);
            }
            return result;
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
