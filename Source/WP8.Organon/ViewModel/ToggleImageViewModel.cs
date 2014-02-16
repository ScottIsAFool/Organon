using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight.Messaging;

namespace WP8.Organon.ViewModel
{
    public class ToggleImageViewModel : OrganonViewModelBase
    {
        public ToggleImageViewModel(INavigationService navigationService, IMessenger messenger) : base(navigationService, messenger)
        {            
        }
    }
}
