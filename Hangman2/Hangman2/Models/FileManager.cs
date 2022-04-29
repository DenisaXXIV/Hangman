using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman2.Models
{
    internal class FileManager
    {
        private readonly string USERS_FILES = "D:/Proiecte/Hangman-Spanzuratoarea/Hangman2/Hangman2/Files/Users.txt";
        private readonly string GAMES_FILES = "D:/Proiecte/Hangman-Spanzuratoarea/Hangman2/Hangman2/Files/Games.txt";

        public void SaveCurrentUser(ObservableCollection<User> usersList)
        {
            if (File.Exists(USERS_FILES))
            {
                string newUser;
                using (StreamWriter sw = File.CreateText(USERS_FILES))
                {
                    foreach (User user in usersList)
                    {
                        newUser = new string(user.Username + " " + user.ProfilePic + " " + user.Points + " " + user.SavedGamesId.Count + " [ ");
                        foreach (var gameID in user.SavedGamesId)
                        {
                            newUser = newUser + gameID + " ";
                        }
                        newUser = newUser + "]";
                        sw.WriteLine(newUser);
                    }
                }
            }
        }

        public ObservableCollection<User> LoadUsersData()
        {
            ObservableCollection<User> players = new ObservableCollection<User>();
            if (File.Exists(USERS_FILES))
            {
                using (StreamReader sr = File.OpenText(USERS_FILES))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        User user = new User();
                        string[] words = line.Split(' ');
                        user.Username = words[0];
                        user.ProfilePic = words[1];
                        user.Points = words[2];
                        for (int index = 1; index <= int.Parse(words[3]); index++)
                        {
                            user.SavedGamesId.Add(int.Parse(words[4 + index]));
                        }
                        players.Add(user);
                    }
                }
            }
            return players;
        }

        public void SaveCurrentGame(ObservableCollection<SavedGame> gamesList)
        {
            if (File.Exists(USERS_FILES))
            {
                string newGame;
                using (StreamWriter sw = File.CreateText(USERS_FILES))
                {
                    foreach (SavedGame game in gamesList)
                    {
                        newGame = new string(game.Id.ToString() + " " + game.Level.ToString() + " " + game.Mistakes
                            + " " + game.Category + " " + game.Word + " " + game.WordGuessed);
                        sw.WriteLine(newGame);
                    }
                }
            }
        }

        public ObservableCollection<SavedGame> LoadGamesData()
        {
            ObservableCollection<SavedGame> games = new ObservableCollection<SavedGame>();
            if (File.Exists(USERS_FILES))
            {
                using (StreamReader sr = File.OpenText(USERS_FILES))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        SavedGame game = new SavedGame();
                        string[] words = line.Split(' ');
                        game.Id = int.Parse(words[0]);
                        game.Level = int.Parse(words[1]);
                        game.Mistakes = words[2];
                        game.Category = words[3];
                        game.Word = words[4];
                        game.WordGuessed = words[5];

                        games.Add(game);
                    }
                }
            }
            return games;
        }

    }
}
