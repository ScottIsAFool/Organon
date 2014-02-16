using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Organon.WP8.ViewModel
{
    public class MainViewModel : OrganonViewModelBase
    {
        public RelayCommand ToggleImageDemo { get; private set; }

        public MainViewModel(INavigationService navigationService, IMessenger messenger) : base(navigationService, messenger)
        {
            this.ToggleImageDemo = new RelayCommand(() => base._navigationService.NavigateTo(ViewModelLocator.ToggleImagePage));
        }
    }
}