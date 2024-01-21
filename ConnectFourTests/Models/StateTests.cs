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

    }
}
