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
        labelTurnPlayer.TextColor = Color.FromArgb("338AFF");
    }

    private void OnTap_Column(object sender, TappedEventArgs args)
    {
        Image image = sender as Image;
        int column = int.Parse(image.ClassId);

        Console.WriteLine($"Tapped column {column}");
        int piecePos = State.PlayPiece(column);
        Console.WriteLine($"{piecePos}");

        string pieceName = $"piece{piecePos.ToString()}_column{column.ToString()}";
        Console.WriteLine(pieceName);
        Ellipse ellipse = (Ellipse)FindByName(pieceName);

        if (State.players[0].isPlaying)
        {
            ellipse.Fill = Color.FromArgb("FF3333");
        }

        if (State.players[1].isPlaying)
        {
            ellipse.Fill = Color.FromArgb("338AFF");
        }

    }
}