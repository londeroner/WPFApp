using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPFApp.Helpers;
using WPFApp.Models;

namespace WPFApp.ViewModels
{
    public abstract class DomainViewModel : INotifyPropertyChanged
    {
        public abstract void SetPropertyFocus(string property);
        public abstract void DisableFocus();
        public abstract DomainModel Save();

        #region Errors Section
        private bool _hasErrors;
        public bool HasErrors
        {
            get { return _hasErrors; }
            set
            {
                _hasErrors = value;
                OnPropertyChanged();
            }
        }

        public List<ErrorModel> Errors = new List<ErrorModel>();

        public delegate void ErrorHandler(DomainViewModel sender, ErrorEventArgs e);
        public event ErrorHandler ValidationChanged;

        protected void OnValidationChanged(ErrorEventArgs e)
        {
            HasErrors = Errors.Count > 0;
            ValidationChanged?.Invoke(this, e);
        }
        #endregion

        #region INotify Implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
