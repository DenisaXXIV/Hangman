using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman2.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Points { get; set; }
        public string ProfilePic { get; set; }
        public List<int> SavedGamesId { get; set; }

        public override string ToString()
        {
            return this.Username + " ";
        }
    }
}
