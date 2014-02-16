using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight.Messaging;

namespace Organon.WP8.ViewModel
{
    public class ToggleImageViewModel : OrganonViewModelBase
    {
        public ToggleImageViewModel(INavigationService navigationService, IMessenger messenger) : base(navigationService, messenger)
        {            
        }
    }
}
