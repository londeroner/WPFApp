using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WPFApp.Helpers;

namespace WPFApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Commands
        private Command _addBuilding;
        public Command AddBuilding
        {
            get
            {
                return _addBuilding ??
                    (_addBuilding = new Command(obj =>
                    {
                        BuildingViewModel bvm = new BuildingViewModel();
                        DomainViewModels.Add(bvm);
                        bvm.ValidationChanged += UpdateErrors;
                        Selected = bvm;
                    }));
            }
        }

        private Command _addParcel;
        public Command AddParcel
        {
            get
            {
                return _addParcel ??
                    (_addParcel = new Command(obj =>
                    {
                        ParcelViewModel pvm = new ParcelViewModel();
                        DomainViewModels.Add(pvm);
                        pvm.ValidationChanged += UpdateErrors;
                        Selected = DomainViewModels.LastOrDefault();
                    }));
            }
        }

        private Command _moveToError;
        public Command MoveToError
        {
            get
            {
                return _moveToError ??
                    (_moveToError = new Command(obj =>
                    {
                        ErrorModel error = obj as ErrorModel;

                        Selected = DomainViewModels.FirstOrDefault(x => x == error.ParentViewModelDomain);
                        Selected.SetPropertyFocus(error.FieldName);
                    }));
            }
        }
        #endregion

        private DomainViewModel _selected;
        public DomainViewModel Selected
        {
            get { return _selected; }
            set 
            {
                if (Selected is { })
                    Selected.DisableFocus();

                _selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }

        public ObservableCollection<DomainViewModel> DomainViewModels { get; set; } = new ObservableCollection<DomainViewModel>();
        public ErrorsViewModel Errors { get; set; } = new ErrorsViewModel();

        public void Save()
        {
            // Call Save on all DomainViewModels, collect data, and save to file/db/etc implemetation

            throw new NotImplementedException();
        }

        private void UpdateErrors(DomainViewModel sender, ErrorEventArgs e)
        {
            foreach (var error in Errors.ErrorsList.ToList())
            {
                if (error.ParentViewModelDomain == sender)
                    Errors.ErrorsList.Remove(error);
            }

            foreach (var error in sender.Errors)
            {
                Errors.ErrorsList.Insert(0, error);
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
