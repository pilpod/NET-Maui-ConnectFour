

using System;

namespace ConnectFour.Models
{
    public class State
    {
        Player[] players;
        int GameRoundsPlayed;
        bool GameOver;
        Piece[] pieces { get; set; }

        public State()
        {
            this.players = new Player[]
            {
                new Player() { Name="Player", Points=0 },
                new Player() {  Name="Opponent", Points=0 }
            };

            this.pieces = new Piece[42];

            this.GameRoundsPlayed = 0;
            this.GameOver = false;
        }

        public void ResetGame()
        {
            GameOver = false;
            players[0].Points = 0;
            players[1].Points = 0;
        }

        public void EndGame()
        {
            GameOver = true;
            GameRoundsPlayed++;
        }

        public void PlayPiece(int position)
        {
            this.pieces[position].isOccupied = true;
        }
    }
}
