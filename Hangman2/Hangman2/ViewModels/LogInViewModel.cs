using Hangman2.Commands;
using Hangman2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hangman2.ViewModels
{
    internal class LogInViewModel : INotifyPropertyChanged
    {
        private string PROFIL_PIC_1 = "D:/Proiecte/Hangman-Spanzuratoarea/images/users/user(1).png";
        private string PROFIL_PIC_2 = "D:/Proiecte/Hangman-Spanzuratoarea/images/users/user(2).png";
        private string PROFIL_PIC_3 = "D:/Proiecte/Hangman-Spanzuratoarea/images/users/user(3).png";
        private string PROFIL_PIC_4 = "D:/Proiecte/Hangman-Spanzuratoarea/images/users/user(4).png";
        private string PROFIL_PIC_5 = "D:/Proiecte/Hangman-Spanzuratoarea/images/users/user(5).png";
        private string PROFIL_PIC_6 = "D:/Proiecte/Hangman-Spanzuratoarea/images/users/user(6).png";
        private string PROFIL_PIC_7 = "D:/Proiecte/Hangman-Spanzuratoarea/images/users/user(7).png";
        private string PROFIL_PIC_8 = "D:/Proiecte/Hangman-Spanzuratoarea/images/users/user(8).png";
        private string PROFIL_PIC_9 = "D:/Proiecte/Hangman-Spanzuratoarea/images/users/user(9).png";
        private string PROFIL_PIC_10 = "D:/Proiecte/Hangman-Spanzuratoarea/images/users/user(10).png";
        private string PROFIL_PIC_11 = "D:/Proiecte/Hangman-Spanzuratoarea/images/users/user(11).png";

        private string m_newUserText = "Enter username...";
        private string m_ImagePath;
        private ObservableCollection<User> m_Users;
        private User m_selectedUser;
        private string m_rightPic;
        private string m_leftPic;
        private ObservableCollection<string> m_picsList;
        private string m_shownPic;

        private FileManager m_fmanager;

        #region ICommands
        private ICommand m_play;
        private ICommand m_deleteUser;
        private ICommand m_newUser;
        private ICommand m_right;
        private ICommand m_left;
        #endregion

        #region public
        public FileManager FileManager
        {
            get { return m_fmanager; }
            set
            {
                if (value != null)
                {
                    m_fmanager = value;
                }
                OnPropertyChanged(nameof(FileManager));
            }
        }
        public string ShownPic
        {
            get { return m_shownPic; }
            set
            {
                if (value != null)
                {
                    m_shownPic = value;
                }
                OnPropertyChanged(nameof(ShownPic));
            }
        }
        public ObservableCollection<string> PicsList
        {
            get { return m_picsList; }
            set
            {
                if (value != null)
                {
                    m_picsList = value;
                }
            }
        }
        public ObservableCollection<User> Users
        {
            get { return m_Users; }
            set
            {
                if (value != null)
                {
                    m_Users = value;
                }
                OnPropertyChanged(nameof(Users));
            }
        }

        public string NewUserText
        {
            get { return m_newUserText; }
            set
            {
                if (value != null)
                {
                    m_newUserText = value;
                }
                OnPropertyChanged(nameof(NewUserText));
            }
        }

        public User SelectedUser
        {
            get { return m_selectedUser; }
            set
            {
                if (value != null)
                {
                    m_selectedUser = value;
                }
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        public string PicPath
        {
            get { return m_ImagePath; }
            set
            {
                if (value != null)
                {
                    m_ImagePath = value;
                }
                OnPropertyChanged(nameof(PicPath));
            }
        }

        public string LeftPic
        {
            get { return m_leftPic; }
            set
            {
                if (value != null)
                {
                    m_leftPic = value;
                }
                OnPropertyChanged(nameof(LeftPic));
            }
        }

        public string RightPic
        {
            get { return m_rightPic; }
            set
            {
                if (value != null)
                {
                    m_rightPic = value;
                }
                OnPropertyChanged(nameof(RightPic));
            }
        }
        #endregion

        #region public ICommans
        public ICommand PlayCommand
        {
            get
            {
                if (m_play == null)
                {
                    m_play = new RelayCommand(_ => PlayGame());
                }
                return m_play;
            }
        }

        public ICommand DeleteUserCommand
        {
            get
            {
                if (m_deleteUser == null)
                {
                    m_deleteUser = new RelayCommand(_ => DeleteUser());
                }
                return m_deleteUser;
            }
        }

        public ICommand NewUserCommand
        {
            get
            {
                if (m_newUser == null)
                {
                    m_newUser = new RelayCommand(_ => NewUser());
                }
                return m_newUser;
            }
        }
        #endregion

        public LogInViewModel()
        {
            //ImagePath = User.ProfilePic;
            PicPath = "D:/Proiecte/Hangman-Spanzuratoarea/images/users/user(1).png";
            RightPic = "D:/Proiecte/Hangman-Spanzuratoarea/Hangman2/Hangman2/dr.png";
            LeftPic = "D:/Proiecte/Hangman-Spanzuratoarea/Hangman2/Hangman2/st.png";

            string path;


            //PicsList.Add(PROFIL_PIC_1);
            //PicsList.Add(PROFIL_PIC_2);
            //PicsList.Add(PROFIL_PIC_3);
            //PicsList.Add(PROFIL_PIC_4);
            //PicsList.Add(PROFIL_PIC_5);
            //PicsList.Add(PROFIL_PIC_6);
            //PicsList.Add(PROFIL_PIC_7);
            //PicsList.Add(PROFIL_PIC_8);
            //PicsList.Add(PROFIL_PIC_9);
            //PicsList.Add(PROFIL_PIC_10);
            //PicsList.Add(PROFIL_PIC_11);

            Users = new ObservableCollection<User>(Utility.FileReader.ReadUsers());

        }

        public void PlayGame()
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }

        public void NewUser()
        {
            if (m_newUserText != null)
            {
                User user = new User { Username = m_newUserText };
                Users.Add(user);

                return;
            }
            MessageBox.Show("Ïnput box is empty");
        }

        public void DeleteUser()
        {
            if (SelectedUser != null)
            {
                Users.Remove(SelectedUser);
                return;
            }
            MessageBox.Show("No user selected!");
        }

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler OnRequestClose;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

    }
}
