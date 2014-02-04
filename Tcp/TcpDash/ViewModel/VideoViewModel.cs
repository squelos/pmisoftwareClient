using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TcpDash.Classes;
using TcpDash.UI;

namespace TcpDash.ViewModel
{
    public class VideoViewModel : ViewModelBase
    {
        #region privates
        private MainViewModel _mvm;
        private Uri _videoSource;
        private string _dirLocation = @"C:\testVideo\";
        private FileSystemWatcher _fsWatcher;
        private List<string> _stringList = new List<string>();
        private string _selectedPath;
        private int _cursor = 0;
        private VideoPlayer _player;
        private RelayCommand _previousCommand;
        private RelayCommand _nextCommand;
        private RelayCommand _pauseCommand;
        private RelayCommand _playCommand;
        #endregion

        #region ctor

        public VideoViewModel(MainViewModel mvm)
        {
            _mvm = mvm;
            InitUriList();
            InitFSWatcher();
            _pauseCommand = new RelayCommand(Pause);
            _nextCommand = new RelayCommand(Next);
            _previousCommand = new RelayCommand(Previous);
            _playCommand = new RelayCommand(Play);
        }
        #endregion

        #region getters/setters

        public Uri Source
        {
            get { return _videoSource; }
            set
            {
                _videoSource = value;
                RaisePropertyChanged("videoSource");
            }
        }

        public ICommand PauseCommand
        {
            get { return _pauseCommand; }
        }
        public ICommand PlayCommand
        {
            get { return _playCommand; }
        }

        public ICommand PreviousCommand
        {
            get { return _previousCommand; }
        }

        public ICommand NextCommand
        {
            get { return _nextCommand; }
        }

        public String SelectedPath
        {
            get { return _selectedPath; }
            set
            {
                _selectedPath = value;
                _videoSource = new Uri(SelectedPath);
                if (_player == null)
                {
                    _player = new VideoPlayer();
                    _player.Owner = UIDispatcher.Instance.GetMainWindow;
                    _player.MinHeight = 1080;
                    _player.MinWidth = 1920;
                }
                try
                {
                    _player.Show();
                }
                catch (Exception)
                {
                    _player = new VideoPlayer();
                    _player.Show();
                    _player.Owner = UIDispatcher.Instance.GetMainWindow;
                    _player.MinHeight = 1080;
                    _player.MinWidth = 1920;
                }
                
                //_player.SetFullScreen();
                _player.Play(_videoSource);
                
                RaisePropertyChanged("selectedPath");
            }
        }

        

        public List<string> Paths
        {
            
            get { return _stringList; }
        }

        #endregion

        #region publics

        #endregion

        #region privateMethods

        private void Previous()
        {
            if (_stringList.Count != 0)
            {
                if (_cursor > 0)
                {
                    _cursor--;
                    
                }
                else
                {
                    _cursor = _stringList.Count - 1;

                }
                SelectedPath = _stringList[_cursor];
            }
        }

        private void Next()
        {
            if (_stringList.Count != 0)
            {
                if (_cursor+1 == _stringList.Count)
                {
                    _cursor = 0;
                }
                else
                {
                    _cursor++;
                }
                SelectedPath = _stringList[_cursor];
            }
        }

        private void Pause()
        {
            if (_player != null)
            {
                _player.Pause();
            }
        }

        private void Play()
        {
            if (_player != null)
            {
                _player.Play();
            }
        }
        private void InitUriList()
        {
            _stringList.Clear();
            string[] allfiles = Directory.GetFiles(_dirLocation, "*.*", SearchOption.AllDirectories);
            foreach (var file in allfiles)
            {
                if (file.EndsWith(".mp4"))
                {
                    _stringList.Add(file);
                }
            }
        }
        private void InitFSWatcher()
        {
            _fsWatcher = new FileSystemWatcher(_dirLocation);
            _fsWatcher.NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastWrite |
                                      NotifyFilters.LastAccess;
            _fsWatcher.IncludeSubdirectories = true;

            _fsWatcher.Changed += _fsWatcher_Changed;
            _fsWatcher.Created += FsWatcherOnCreated;
            _fsWatcher.Deleted += FsWatcherOnDeleted;
            _fsWatcher.Renamed += FsWatcherOnRenamed;

            _fsWatcher.EnableRaisingEvents = true;
        }

        private void FsWatcherOnRenamed(object sender, RenamedEventArgs e)
        {
            _stringList.Remove(_stringList.Find(s => s == e.OldFullPath));
            _stringList.Add(e.FullPath);
        }

        private void FsWatcherOnDeleted(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            _stringList.Remove(_stringList.Find(s => s == fileSystemEventArgs.FullPath));
        }

        private void FsWatcherOnCreated(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            _stringList.Add(fileSystemEventArgs.FullPath);
        }

        void _fsWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            InitUriList();
        }

        #endregion

        #region events
        #endregion
    }
}
