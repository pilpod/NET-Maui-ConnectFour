using ConnectFour.Models;
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
            State state = new State();

            await Navigation.PushAsync(new BoardView(state));
        }
    }
}