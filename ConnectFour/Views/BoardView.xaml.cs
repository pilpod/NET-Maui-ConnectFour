using ConnectFour.Models;
using Microsoft.Maui.Controls.Shapes;

namespace ConnectFour.Views;

public partial class BoardView : ContentPage
{
    State State { get; set; }
    public BoardView(State state)
    {
        InitializeComponent();
        this.State = state;

        // color red : FF3333
        // color blue : 338AFF

        labelTurnPlayer.Text = "Turn Player 1";
        labelTurnPlayer.TextColor = Color.FromArgb("FF3333");
    }

    private void OnTap_Column(object sender, TappedEventArgs args)
    {
        Image image = sender as Image;
        int column = int.Parse(image.ClassId);

        int piecePos = State.PlayPiece(column);
        string pieceName = $"piece{piecePos.ToString()}_column{column.ToString()}";
        Ellipse ellipse = (Ellipse)FindByName(pieceName);

        if (State.players[1].isPlaying)
        {
            ellipse.Fill = Color.FromArgb("FF3333");
            labelTurnPlayer.TextColor = Color.FromArgb("338AFF");
            labelTurnPlayer.Text = "Turn Player 2";
        }

        if (State.players[0].isPlaying)
        {
            ellipse.Fill = Color.FromArgb("338AFF");
            labelTurnPlayer.TextColor = Color.FromArgb("FF3333");
            labelTurnPlayer.Text = "Turn Player 1";
        }

    }
}