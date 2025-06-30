using Microsoft.Maui.Controls;

namespace GreenChatMobileMaui
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }


        private async void OnGoToDiscussionsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Discussions");
        }
    }
}
