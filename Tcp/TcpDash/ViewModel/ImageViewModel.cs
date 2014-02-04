using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using TcpDash.Business;
using TcpDash.Classes;

namespace TcpDash.ViewModel
{
    public class ImageViewModel : ViewModelBase
    {
        #region privates
        private string _dirLocation = @"C:\testImg\";
        private FileSystemWatcher _fsWatcher;
        private List<string> _stringList = new List<string>();
        private int _iterator = 0;
        private bool _rotation = true;
        private ImageSource _source;
        private MainViewModel _mvm;
        private bool _stopRotation = false;
        #endregion

        #region ctor
        public ImageViewModel(MainViewModel mvm)
        {
            _mvm = mvm;
            InitUriList();
            InitFSWatcher();
            InitRotation();
        }
        #endregion

        #region getters/setters

        public ImageSource Source
        {
            get { return _source; }
            set
            {
                _source = value;
                RaisePropertyChanged("source");
            }
        }

        public bool StopRotation
        {
            get { return _stopRotation; }
            set
            {
                _stopRotation = value;
                RaisePropertyChanged("stopRotation");
            }
        }
        #endregion

        #region events

        public delegate void RequestMoveLeft(object sender, ImageSource imgSource);
        public event RequestMoveLeft MoveLeft;
        public delegate void RequestMoveRight(object sender, ImageSource imgSource);
        public event RequestMoveRight MoveRight;
        public delegate void RequestFade(object sender, ImageSource imgSource);
        public event RequestFade Fade;

        public void RaiseMoveLeft(ImageSource src)
        {
            if (MoveLeft != null)
            {
                MoveLeft(this, src);
            }
        }
        public void RaiseMoveRight(ImageSource src)
        {
            if (MoveRight != null)
            {
                MoveRight(this, src);
            }
        }

        public void RaiseFade(ImageSource src)
        {
            if (Fade != null)
            {
                Fade(this, src);
            }
        }

        #endregion

        #region public

        public void Back()
        {
            //TODO buggy as fuck
            if (_stringList.Count != 0)
            {
                if (_iterator > 0)
                {
                    _iterator--;
                }
                else
                {
                    _iterator = _stringList.Count - 1;
                }

                ImageSource source;
                BitmapImage bmpImage = new BitmapImage();
                bmpImage.BeginInit();

                bmpImage.UriSource = new Uri(_stringList[_iterator]);
                bmpImage.EndInit();
                source = bmpImage;
                RaiseMoveLeft(source);
            }
        }

        public void Forward()
        {
            //TODO buggy as fuck a bite
            if (_stringList.Count != 0)
            {
                if (_iterator + 1 == _stringList.Count)
                {
                    _iterator = 0;
                }
                else
                {
                    _iterator++;
                }
                ImageSource source;
                BitmapImage bmpImage = new BitmapImage();
                bmpImage.BeginInit();

                bmpImage.UriSource = new Uri(_stringList[_iterator]);
                bmpImage.EndInit();
                source = bmpImage;
                RaiseMoveRight(source);
            }
        }
        #endregion

        #region private methods
        private void ShowImage(Uri uri)
        {
            if (UIDispatcher.Instance.GetMainWindow != null)
            {
                UIDispatcher.Instance.Invoke(() =>
                {
                    BitmapImage bmpImage = new BitmapImage();
                    bmpImage.BeginInit();

                    bmpImage.UriSource = uri;
                    bmpImage.EndInit();
                    Source = bmpImage;
                    RaiseFade(bmpImage);
                });
            }
        }

        private void InitUriList()
        {
            _stringList.Clear();
            string[] allfiles = Directory.GetFiles(_dirLocation, "*.*", SearchOption.AllDirectories);
            foreach (var file in allfiles)
            {
                if (file.EndsWith(".png") || file.EndsWith(".jpg") || file.EndsWith(".jpeg") || file.EndsWith(".bmp"))
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

        private void InitRotation()
        {
            if (_stringList.Count != 0)
            {
                BitmapImage bmpImage = new BitmapImage();
                bmpImage.BeginInit();

                bmpImage.UriSource = new Uri(_stringList[_iterator]);
                bmpImage.EndInit();
                Source = bmpImage;
            }
            Task t = new Task(() =>
            {
                //TODO buggy as fuck
                while (_rotation)
                {

                    if (_stringList.Count != 0 && !StopRotation)
                    {
                        if (_iterator == _stringList.Count - 1)
                        {
                            _iterator = 0;
                        }

                        ShowImage(new Uri(_stringList[_iterator]));
                        _iterator++;
                    }
                    Thread.Sleep(15000);

                }
                // Load the first img if there is one

                //wait
            });
            t.Start();
        }
        #endregion

    }
}
