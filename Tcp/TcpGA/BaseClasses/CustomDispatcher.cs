using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TcpDataModel;

namespace TcpGA.BaseClasses
{
    class CustomDispatcher
    {
        #region members

        private MainWindow _uiElement;
        #endregion

        #region singleton
        private static readonly Lazy<CustomDispatcher> lazy =
            new Lazy<CustomDispatcher>(() => new CustomDispatcher());

        public static CustomDispatcher Instance { get { return lazy.Value; } }

        private CustomDispatcher()
        {

        }

        #endregion

        #region public

        public delegate void RequestFlyoutHandler(string text);

        public event RequestFlyoutHandler BadgeRequest;
        public event RequestFlyoutHandler TrainingRequest;
        public event RequestFlyoutHandler BookingPrefRequest;
        public event RequestFlyoutHandler BookingRequest;
        public event RequestFlyoutHandler CategoriesRequest;

        /// <summary>
        /// Registers the UI and returns true if the UI was already registered
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Returns true if the UI was already registered</returns>
        public bool RegisterUI(MainWindow element)
        {
            if (_uiElement != null)
            {
                _uiElement = element;
                return false;
            }
            else
            {
                _uiElement = element;
                return true;
            }

        }

        public MainWindow GetMainWindow
        {
            get { return _uiElement; }
        }

        public void BeginInvoke(Action action)
        {
            _uiElement.Dispatcher.BeginInvoke(DispatcherPriority.Background, action);
        }

        public void RequestFlyout(string str)
        {
            switch (str)
            {
                case "badge":
                    RaiseBadgeRequest();
                    break;
                case "training":
                    RaiseTrainingRequest();
                    break;
                case "bookingPref":
                    RaisebookingPrefRequest();
                    break;
                case "booking":
                    RaiseBookingRequest();
                    break;
                case "categories":
                    RaiseCategoryRequest();
                    break;
            }
        }
        #endregion

        #region privateRaising

        private void RaiseBadgeRequest()
        {
            if (BadgeRequest != null)
            {
                BadgeRequest("badge");
            }
        }
        private void RaiseTrainingRequest()
        {
            if (TrainingRequest != null)
            {
                TrainingRequest("training");
            }
        }
        private void RaisebookingPrefRequest()
        {
            if (BookingPrefRequest != null)
            {
                BookingPrefRequest("bookingPref");
            }
        }

        private void RaiseBookingRequest()
        {
            if (BookingRequest != null)
            {
                BookingRequest("booking");
            }
        }

        private void RaiseCategoryRequest()
        {
            if (CategoriesRequest != null)
            {
                CategoriesRequest("category");
            }
        }
        #endregion
    }
}
