using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPFApp.Helpers;

namespace WPFApp.ViewModels
{
    public class ErrorsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ErrorModel> errorsList = new ObservableCollection<ErrorModel>();
        public ObservableCollection<ErrorModel> ErrorsList
        {
            get { return errorsList; }
            set
            {
                errorsList = value;
                OnPropertyChanged(nameof(ErrorsList));
            }
        }

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
