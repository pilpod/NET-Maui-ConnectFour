

using System;

namespace ConnectFour.Models
{
    public class State
    {
        public readonly Player[] players;
        int GameRoundsPlayed;
        bool GameOver;
        public Piece[] pieces { get; set; }

        public State()
        {
            this.players = new Player[]
            {
                new Player() { Name="Player", Points=0, isPlaying=false },
                new Player() {  Name="Opponent", Points=0, isPlaying=true }
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

        public int PlayPiece(int position)
        {
            int index = position * 6;
            int columnLength = index + 6;

            for (int i = index; i < columnLength; i++)
            {
                if (this.pieces[i] == null)
                {
                    Console.WriteLine("No pieces");
                    this.pieces[i] = new Piece();
                    this.pieces[i].IsOccupied = true;
                    ChangeTurn();
                    return i;
                }
                Console.WriteLine("Occupied by a piece");
                continue;
            }

            return 0;
        }

        public void ChangeTurn()
        {
            if (players[0].isPlaying)
            {
                players[0].isPlaying = false;
                players[1].isPlaying = true;
                return;
            }

            players[0].isPlaying = true;
            players[1].isPlaying = false;

        }
    }
}
