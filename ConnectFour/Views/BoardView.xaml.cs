namespace ConnectFour.Views;

public partial class BoardView : ContentPage
{
	public BoardView()
	{
		InitializeComponent();
	}

	private void OnTap_Column1(object sender, TappedEventArgs args)
	{
		Console.WriteLine("Tapped box 1");
		box1_column1.Fill = Color.Parse("red");
	}
}