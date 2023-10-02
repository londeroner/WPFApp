using System;
using System.ComponentModel;
using WPFApp.Helpers;
using WPFApp.Models;

namespace WPFApp.ViewModels
{
    public class BuildingViewModel : DomainViewModel, IDataErrorInfo
    {
        #region Properties
        private string _floorCount;
        public string FloorCount 
        {
            get { return _floorCount; }
            set
            {
                _floorCount = value;
                OnPropertyChanged();
            }
        }

        private bool _floorFocused;
        public bool FloorFocused
        {
            get { return _floorFocused; }
            set
            {
                _floorFocused = value;

                if (value && AddressFocused)
                    AddressFocused = false;

                OnPropertyChanged();
            }
        }

        private string _address;
        public string Address 
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        private bool _addressFocused;
        public bool AddressFocused
        {
            get { return _addressFocused; }
            set
            {
                _addressFocused = value;

                if (value && FloorFocused)
                    FloorFocused = false;

                OnPropertyChanged();
            }
        }

        private bool _isLiving;
        public bool IsLiving 
        { 
            get { return _isLiving; }
            set
            {
                _isLiving = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public BuildingModel Model { get; set; }

        public BuildingViewModel()
        {
            Model = new BuildingModel();
        }

        public override void SetPropertyFocus(string property)
        {
            switch (property)
            {
                case nameof(FloorCount):
                    FloorFocused = true;
                    break;
                case nameof(Address):
                    AddressFocused = true;
                    break;
            }
        }

        public override void DisableFocus()
        {
            FloorFocused = false;
            AddressFocused = false;
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
                    case nameof(FloorCount):
                        Errors = Errors.RemoveErrorsByField(columnName);
                        bool isNumber = int.TryParse(FloorCount, out int value);

                        if (string.IsNullOrEmpty(FloorCount))
                        {
                            error = new ErrorModel(this, Model.Id, "Поле не должно быть пустым", nameof(FloorCount));
                            Errors.Add(error);
                        }
                        else if (!isNumber)
                        {
                            error = new ErrorModel(this, Model.Id, "Поле должно быть заполнено числовым значением", nameof(FloorCount));
                            Errors.Add(error);
                        }
                        else if (value <= 0)
                        {
                            error = new ErrorModel(this, Model.Id, "Значение поля должно быть больше 0", nameof(FloorCount));
                            Errors.Add(error);
                        }
                        break;
                    case nameof(Address):
                        Errors = Errors.RemoveErrorsByField(columnName);

                        if (string.IsNullOrEmpty(Address))
                        {
                            error = new ErrorModel(this, Model.Id, "Поле не должно быть пустым", nameof(Address));
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
