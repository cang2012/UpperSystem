using Caliburn.Micro;
using System;
using System.ComponentModel;

namespace UpperSystem.ViewModels
{
    public class LoginViewModel : PropertyChangedBase
    {
        private string _loginName;

        public string LoginName
        {
            get => _loginName;
            set
            {
                if (_loginName != value)
                {
                    Set(ref _loginName, value);
                    NotifyOfPropertyChange(() => LoginName);
                }
            }
        }

        public string Password { get; set; } = "333";
        public bool IsNotifying { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyOfPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}
