using ConnectFour.Models;
using System;
using Xunit;


namespace ConnectFourTests.Models
{
    public class StateTests
    {
        [Fact]
        public void StateCanResetGame()
        {
            State state = new State();
            state.GameOver = true;
            state.players[0].Points = 2;
            state.players[1].Points = 3;

            state.PlayPiece(0);
            state.ResetGame();

            Assert.False(state.GameOver);
            Assert.Equal(0, state.players[0].Points);
            Assert.Equal(0, state.players[1].Points);
            Assert.All(state.pieces, piece => Assert.Null(piece));
        }

        [Fact]
        public void StateCanSetEndGame()
        {
            State state = new State();
            state.GameOver = false;
            state.PlayPiece(1);
            state.EndGame();

            Assert.True(state.GameOver);
            Assert.Equal(1, state.GameRoundsPlayed);
            Assert.All(state.pieces, piece => Assert.Null(piece));

        }

        [Fact]
        public void StatePlayPieceColumn1Row1()
        {
            State state = new State();

            state.PlayPiece(0);

            Assert.NotNull(state.pieces[0]);
            Assert.True(state.pieces[0] is Piece);
            Assert.True(state.pieces[0].IsOccupied);
            Assert.Null(state.pieces[1]);
        }

        [Fact]
        public void StateCanChangePlayerTurnPlayer1Playing()
        {
            State state = new State();

            Player player1 = state.players[0];
            Player player2 = state.players[1];

            player1.isPlaying = true;
            player2.isPlaying = false;

            state.ChangeTurn();

            Assert.False(player1.isPlaying);
            Assert.True(player2.isPlaying);
        }

        [Fact]
        public void StateCanChangePlayerTurnPlayer2PlayingReverse()
        {
            State state = new State();

            Player player1 = state.players[0];
            Player player2 = state.players[1];

            player1.isPlaying = false;
            player2.isPlaying = true;

            state.ChangeTurn();

            Assert.True(player1.isPlaying);
            Assert.False(player2.isPlaying);
        }

        [Fact]
        public void StateCanCheckIfWin_Vertical()
        {
            int position = 3;
            int player = 1;
            State state = new State();
            Piece piece = new Piece();
            piece.IsOccupied = true;
            piece.PlayedBy = 1;

            for (int i = 0; i < 4; i++) state.pieces[i] = piece;

            bool win = state.CheckIfPlayerWin(position, player);

            Assert.True(win);

        }

        [Fact]
        public void StateCanCheckIfWin_Horitzontal()
        {
            int position = 18;
            int player = 1;
            State state = new State();
            Piece piece = new Piece();
            piece.IsOccupied = true;
            piece.PlayedBy = 1;

            for (int i = 12; i >= 0; i -= 6) state.pieces[i] = piece;

            bool win = state.CheckIfPlayerWin(position, player);

            Assert.True(win);
        }

        [Fact]
        public void StateCanCheckIfWin_DiagonalUpLeftRight()
        {
            int position = 0;
            int player = 1;
            State state = new State();
            Piece piece = new Piece();
            piece.IsOccupied = true;
            piece.PlayedBy = 1;

            for (int i = 21; i >= 7; i -= 7) state.pieces[i] = piece;

            bool win = state.CheckIfPlayerWin(position, player);

            Assert.True(win);
        }
    }
}
