using System.Runtime.CompilerServices;
using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace WP8.Organon.ViewModel
{
    public class OrganonViewModelBase : ViewModelBase
    {
        protected INavigationService _navigationService;

        private bool _viewLoadedCommandEnabled = true;
        public bool ViewLoadedCommandEnabled
        {
            get
            {
                return _viewLoadedCommandEnabled;
            }
            set
            {
                if (_viewLoadedCommandEnabled == value)
                    return;

                _viewLoadedCommandEnabled = value;
                RaisePropertyChanged();
            }
        }

        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (value == _isBusy)
                    return;

                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand ViewLoadedCommand { get; protected set; }

        public OrganonViewModelBase()
        {            
        }

        public OrganonViewModelBase(INavigationService navigationService, IMessenger messenger)
            : base(messenger)
        {
            _navigationService = navigationService;
        }

        protected override void RaisePropertyChanged([CallerMemberName]string property = "")
        {
            base.RaisePropertyChanged(property);
        }
    }
}
