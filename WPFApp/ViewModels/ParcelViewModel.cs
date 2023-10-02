using System;
using System.ComponentModel;
using WPFApp.Helpers;
using WPFApp.Models;

namespace WPFApp.ViewModels
{
    public class ParcelViewModel : DomainViewModel, IDataErrorInfo
    {
        #region Properties
        private string _number;
        public string Number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }

        private bool _numberFocused;
        public bool NumberFocused
        {
            get
            {
                return _numberFocused;
            }
            set 
            { 
                _numberFocused = value;

                if (value && LocationFocused)
                    LocationFocused = false;

                OnPropertyChanged();
            }
        }

        private string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }

        private bool _locationFocused;
        public bool LocationFocused
        {
            get
            {
                return _locationFocused;
            }
            set
            {
                _locationFocused = value;

                if (value && NumberFocused)
                    NumberFocused = false;

                OnPropertyChanged();
            }
        }
        #endregion

        public ParcelModel Model { get; set; }

        public ParcelViewModel()
        {
            Model = new ParcelModel();
        }

        public override void SetPropertyFocus(string property)
        {
            switch (property)
            {
                case nameof(Number):
                    NumberFocused = true;
                    break;
                case nameof(Location):
                    LocationFocused = true;
                    break;
            }
        }

        public override void DisableFocus()
        {
            NumberFocused = false;
            LocationFocused = false;
        }

        public override DomainModel Save()
        {
            // Mapping ViewModel properties to Model and return DomainModel

            throw new NotImplementedException();
        }

        #region IDataErrorInfo Implementation
        public string this[string columnName]
        {
            get
            {
                ErrorModel error = null;

                switch (columnName)
                {
                    case nameof(Number):
                        Errors = Errors.RemoveErrorsByField(columnName);

                        if (string.IsNullOrEmpty(Number))
                        {
                            error = new ErrorModel(this, Model.Id,  "Поле не должно быть пустым", nameof(Number));
                            Errors.Add(error);
                        }
                        break;
                    case nameof(Location):
                        Errors = Errors.RemoveErrorsByField(columnName);

                        if (string.IsNullOrEmpty(Location))
                        {
                            error = new ErrorModel(this, Model.Id, "Поле не должно быть пустым", nameof(Location));
                            Errors.Add(error);
                        }
                        break;
                }
                OnValidationChanged(new ErrorEventArgs(error));

                return error is { } ? error.Message : String.Empty;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
    }
}
