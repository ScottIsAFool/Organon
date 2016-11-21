using System;
using Xamarin.Forms;

namespace Organon.XForms.SampleApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnEntryButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EntryPage());
        }

        private void OnViewButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ViewPage());
        }
    }
}
