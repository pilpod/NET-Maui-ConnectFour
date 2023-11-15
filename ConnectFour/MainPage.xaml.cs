using ConnectFour.Views;
using System;
namespace ConnectFour
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void StartGameButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BoardView());
        }
    }
}