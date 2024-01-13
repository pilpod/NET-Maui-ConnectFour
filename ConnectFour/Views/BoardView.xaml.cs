using ConnectFour.Models;
using Microsoft.Maui.Controls.Shapes;
using Plugin.Maui.Audio;

namespace ConnectFour.Views;

public partial class BoardView : ContentPage
{
    private readonly IAudioManager audioManager;

    State State { get; set; }

    public BoardView(State state)
    {
        InitializeComponent();
        this.State = state;

        // color red : FF3333
        // color blue : 338AFF

        labelTurnPlayer.Text = "Turn Player 1";
        labelTurnPlayer.TextColor = Color.FromArgb("FF3333");

        this.audioManager = AudioManager.Current;

    }

    private void OnTap_Column(object sender, TappedEventArgs args)
    {
        Image image = sender as Image;
        int column = int.Parse(image.ClassId);

        if (!State.GameOver)
        {
            int piecePos = State.PlayPiece(column);
            string pieceName = $"piece{piecePos.ToString()}_column{column.ToString()}";
            Ellipse ellipse = (Ellipse)FindByName(pieceName);

            this.PlayPieceSound();
            this.RenderPlayersPoints();

            if (State.players[1].isPlaying)
            {
                ellipse.Fill = Color.FromArgb("FF3333");
                this.TurnPlayer(2);
            }

            if (State.players[0].isPlaying)
            {
                ellipse.Fill = Color.FromArgb("338AFF");
                this.TurnPlayer(1);
            }

            if (State.CheckIfColumnFull(column)) image.IsEnabled = false;
        }

        if (State.GameOver)
        {
            labelTurnPlayer.TextColor = Color.FromArgb("000000");
            labelTurnPlayer.Text = "Game Over";
            btn_newgame.IsVisible = true;
            btn_reset_game.IsVisible = true;
        }
    }

    private void StartNewGame(object sender, EventArgs e)
    {
        State.NewGame();

        this.TurnPlayer(1);

        this.DisableBtn();
        this.CleanBoard();
        this.EnableArrowButtons();
    }

    private void ResetGame(object sender, EventArgs e)
    {
        State.ResetGame();
        this.CleanBoard();
        this.EnableArrowButtons();
        this.RenderPlayersPoints();
        this.DisableBtn();
        this.TurnPlayer(1);
    }

    private void CleanBoard()
    {
        IEnumerable<Ellipse> ellipses = myGrid.GetVisualTreeDescendants().OfType<Ellipse>();

        foreach (var piece in ellipses)
        {
            Console.WriteLine(piece.Fill);
            piece.Fill = Color.FromArgb("FFFFFF");
        }
    }

    private void EnableArrowButtons()
    {
        IEnumerable<Image> images = myGrid.GetVisualTreeDescendants().OfType<Image>();

        foreach (var image in images)
        {
            image.IsEnabled = true;
        }
    }

    private void DisableBtn()
    {
        btn_newgame.IsVisible = false;
        btn_reset_game.IsVisible = false;
    }

    private void RenderPlayersPoints()
    {
        player_one_points.Text = $"Player 1 Points : {State.players[0].Points}";
        player_two_points.Text = $"Player 2 Points : {State.players[1].Points}";
    }

    private void TurnPlayer(int player)
    {
        if (player == 1)
        {
            labelTurnPlayer.TextColor = Color.FromArgb("FF3333");
            labelTurnPlayer.Text = "Turn Player " + player;
        }

        if (player == 2)
        {
            labelTurnPlayer.TextColor = Color.FromArgb("338AFF");
            labelTurnPlayer.Text = "Turn Player " + player;
        }
    }

    private async void PlayPieceSound()
    {
        var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("piece_falling_down.wav"));

        player.Play();
    }

}