using System.ComponentModel;
using System.Data.Entity.Validation;
using TcpDataModel;

namespace TcpModernUI.BaseClasses
{
    public abstract class ViewModelBase : INotifyPropertyChanging, INotifyPropertyChanged
    {
        #region members
        private entityContainer _container = new entityContainer();
        #endregion

        #region errorEvents
        public delegate void EntityValidationHandler(object sender, DbEntityValidationException e);

        public delegate void CustomErrorHandler(object sender, string e);

        public event EntityValidationHandler ValidationErrorsChanged;
        public event CustomErrorHandler CustomErrorsChanged;

        #endregion

        protected entityContainer Container
        {
            get { return _container; }

        }

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Administrative Properties

        /// <summary>
        /// Whether the view model should ignore property-change events.
        /// </summary>
        public virtual bool IgnorePropertyChangeEvents { get; set; }

        #endregion

        #region Public Methods

        protected bool CommitChanges()
        {
            try
            {
                _container.SaveChanges();
                RaisePropertyChangedEvent("container");
                return true;
            }
            catch (DbEntityValidationException validationException)
            {
                RaiseValidationErrorsEvent(validationException);
            }
           return false;
        }

        protected void ResetContainer()
        {
            _container = new entityContainer();
            RaisePropertyChangedEvent("container");
        }

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the changed property.</param>
        public virtual void RaisePropertyChangedEvent(string propertyName)
        {
            // Exit if changes ignored
            if (IgnorePropertyChangeEvents) return;

            // Exit if no subscribers
            if (PropertyChanged == null) return;

            // Raise event
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChanged(this, e);
        }

        /// <summary>
        /// Raises the PropertyChanging event.
        /// </summary>
        /// <param name="propertyName">The name of the changing property.</param>
        public virtual void RaisePropertyChangingEvent(string propertyName)
        {
            // Exit if changes ignored
            if (IgnorePropertyChangeEvents) return;

            // Exit if no subscribers
            if (PropertyChanging == null) return;

            // Raise event
            var e = new PropertyChangingEventArgs(propertyName);
            PropertyChanging(this, e);
        }

        public void RaiseValidationErrorsEvent(DbEntityValidationException validationException)
        {
            if (IgnorePropertyChangeEvents) return;

            if (ValidationErrorsChanged == null) return;

            ValidationErrorsChanged(this, validationException);
        }

        public void RaiseCustomError(string message)
        {
            if (IgnorePropertyChangeEvents) return;

            if (CustomErrorsChanged == null) return;

            CustomErrorsChanged(this, message);
        }
        #endregion
    }
}
