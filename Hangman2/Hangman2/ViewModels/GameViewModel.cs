using Hangman2.Commands;
using Hangman2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Hangman2.ViewModels
{
    internal class GameViewModel : INotifyPropertyChanged
    {
        #region TextProperties
        private string m_wordToBeGuessed;
        private string m_currentMissedLetter;

        public string WordToBeGuessed
        {
            get { return m_wordToBeGuessed; }
            set
            {
                if (value != null)
                {
                    m_wordToBeGuessed = value;
                }
                OnPropertyChanged(nameof(WordToBeGuessed));
            }
        }

        public string CurrentMissedLetter
        {
            get { return m_currentMissedLetter; }
            set
            {
                if (value != null)
                {
                    m_currentMissedLetter = value;
                }
                OnPropertyChanged(nameof(CurrentMissedLetter));
            }
        }
        #endregion
        #region ImageRegion

        private string m_ImagePath;

        public string ImagePath
        {
            get { return m_ImagePath; }
            set
            {
                if (value != null)
                {
                    m_ImagePath = value;
                }
                OnPropertyChanged(nameof(ImagePath));
            }
        }
        #endregion

        private Stopwatch stopwatch = new Stopwatch();

        private string m_timeLabel;

        public string TimeLabel
        {
            get { return m_timeLabel; }
            set
            {
                if (value != null)
                {
                    m_timeLabel = value;
                }
                OnPropertyChanged(nameof(TimeLabel));
            }
        }

        private ICommand m_GetInput;
        private ICommand m_reloadGame;
        private ICommand m_Help;
        private ICommand m_exitGame;
        private ICommand m_timer;

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region PublicCommands
        public ICommand GetInputCommand
        {
            get
            {
                if (m_GetInput == null)
                {
                    m_GetInput = new RelayCommand(param => GetInput(param));
                }
                return m_GetInput;
            }
        }

        public ICommand HelpCommand
        {
            get
            {
                if (m_Help == null)
                {
                    m_Help = new RelayCommand(param => HelpMessage());
                }
                return m_Help;
            }
        }

        public ICommand ReloadGame
        {
            get
            {
                if (m_reloadGame == null)
                {
                    m_reloadGame = new RelayCommand(param => ReloadGameMethod());
                }
                return m_reloadGame;
            }
        }

        public ICommand ExitCommand
        {
            get
            {
                if (m_exitGame == null)
                {
                    m_exitGame = new RelayCommand(param => ExitMethod());
                }
                return m_exitGame;
            }
        }

        public ICommand TimerCommand
        {
            get
            {
                if (m_timer == null)
                {
                    m_timer = new RelayCommand(param => TimerMethod());
                }
                return m_timer;
            }
        }
        #endregion
        #region MissedLetters
        private List<string> m_missedShots;
        public List<string> MissedShots
        {
            get => m_missedShots;
            set
            {
                if (value != null)
                {
                    m_missedShots = value;
                }
                OnPropertyChanged(nameof(MissedShots));
            }
        }
        #endregion
        public GameViewModel()
        {
            stopwatch = Stopwatch.StartNew();
            m_timeLabel = stopwatch.Elapsed.Seconds.ToString();
            WordToBeGuessed = Game.GuessedWord;
            ImagePath = Game.ImagePath;
            MissedShots = Game.WordControl;
            //UpdateTimer();
        }

        public void UpdateTimer()
        {
            while (stopwatch.Elapsed.Seconds < 30)
            {
                m_timeLabel = stopwatch.Elapsed.Seconds.ToString();
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void GetInput(object parameter)
        {
            try
            {
                Game.ReadChar(parameter.ToString());
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("Duplicate letter");
                return;
            }
            ImagePath = Game.ImagePath;
            WordToBeGuessed = Game.GuessedWord;
            MissedShots = Game.WordControl;
        }

        public void ReloadGameMethod()
        {
            Game.ReloadGame();
            ImagePath = Game.ImagePath;
            WordToBeGuessed = Game.GuessedWord;
            MissedShots = Game.WordControl;
        }

        public void HelpMessage()
        {
            MessageBox.Show("Vasile Denisa-Georgiana\ngrupa 10LF203\nInformatica");
            return;
        }

        public void ExitMethod()
        {
            Application.Current.Shutdown();
        }

        public void TimerMethod()
        {

        }
    }
}
