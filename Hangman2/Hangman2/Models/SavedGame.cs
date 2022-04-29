using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman2.Models
{
    internal class SavedGame
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public string Mistakes { get; set; }
        public string Category { get; set; }
        public string Word { get; set; }
        public string WordGuessed { get; set; }
    }
}
