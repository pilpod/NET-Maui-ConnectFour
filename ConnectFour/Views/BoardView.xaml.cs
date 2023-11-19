namespace ConnectFour.Views;

public partial class BoardView : ContentPage
{
	public BoardView()
	{
		InitializeComponent();
	}

	private void OnTap_Column(object sender, TappedEventArgs args)
	{
		Image image = sender as Image;

		
		Console.WriteLine($"Tapped column {image.ClassId}");
		piece1_column1.Fill = Color.Parse("red");
	}
}