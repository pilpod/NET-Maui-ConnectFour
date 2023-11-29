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
	}

	private void OnTap_Column(object sender, TappedEventArgs args)
	{
		Image image = sender as Image;
		int column = int.Parse(image.ClassId);

        Console.WriteLine($"Tapped column {column}");
        int piecePos = State.PlayPiece(column);
		Console.WriteLine($"{ piecePos }");

        string pieceName = $"piece{piecePos.ToString()}_column{column.ToString()}";
        Console.WriteLine(pieceName);
        Ellipse ellipse = (Ellipse)FindByName(pieceName);

		ellipse.Fill = Color.Parse("red");

    }
}