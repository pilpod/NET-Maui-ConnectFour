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

    }
}
