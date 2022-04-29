using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Hangman2.Models
{
    public static class Game
    {
        public const string WIN_MESSAGE = "Winner winner chicken dinner!";
        private const string LOSE_MESSAGE = "Try again!";
        private const string FIRST_IMAGE_PATH = "D:/Proiecte/Hangman-Spanzuratoarea/images/Hang (0).png";

        public static GameState GameStatus { get; set; }
        public static string Word { get; set; }
        public static string GuessedWord { get; set; }
        public static List<string> WordControl { get; set; }


        public static string ImagePath { get; set; }

        private static List<string> readWords = new List<string>();

        static Game()
        {
            GuessedWord = String.Empty;
            readWords = Utility.FileReader.ReadWords();

            PickRandomWord();
            ImagePath = FIRST_IMAGE_PATH;

            WordControl = new();
        }

        public static void ReadChar(string myChar)
        {
            if (WordControl.Contains(myChar) && !Word.Contains(myChar))
            {
                throw new ArgumentException(nameof(myChar));
            }
            if (Word.Contains(myChar))
            {
                var positions = GetAllIndexes(Word, myChar).ToList();
                for (int index = 0; index < positions.Count; index++)
                {
                    GuessedWord = GuessedWord.Remove(positions[index], 1);
                    GuessedWord = GuessedWord.Insert(positions[index], myChar);
                }

            }
            else
            {
                WordControl.Add(myChar);
                ChangeImage();
            }
            if (WordControl.Count == 6)
            {
                GameStatus = GameState.Looser;
                MessageBox.Show(LOSE_MESSAGE);
                return;
            }
            if (!GuessedWord.Contains("?"))
            {
                GameStatus = GameState.Winner;
                MessageBox.Show(WIN_MESSAGE);
            }
        }

        public static void ChangeImage()
        {
            int stage = WordControl.Count;

            ImagePath = "D:/Proiecte/Hangman-Spanzuratoarea/images/Hang (" + stage + ").png";
        }

        private static void PickRandomWord()
        {
            GuessedWord = String.Empty;
            var random = new Random();
            var position = random.Next(0, readWords.Count - 1);
            Word = readWords[position];
            for (int index = 0; index < Word.Length; index++)
            {
                GuessedWord += "?";
            }
        }

        public static void ReloadGame()
        {
            WordControl = new List<string>();
            PickRandomWord();
            ImagePath = "D:/Proiecte/Hangman-Spanzuratoarea/images/Hang (0).png";
        }

        public static IEnumerable<int> GetAllIndexes(this string source, string matchString)
        {
            matchString = Regex.Escape(matchString);
            foreach (Match match in Regex.Matches(source, matchString))
            {
                yield return match.Index;
            }
        }
    }
}
