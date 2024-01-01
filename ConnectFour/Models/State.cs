

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
                new Player() { Name="Player", Points=0, isPlaying=true },
                new Player() {  Name="Opponent", Points=0, isPlaying=false }
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
                    // No pieces
                    this.pieces[i] = new Piece();
                    this.pieces[i].IsOccupied = true;

                    if (players[0].isPlaying)
                    {
                        this.pieces[i].PlayedBy = 1;
                        bool playerWin = CheckIfPlayerWin(i, this.pieces[i].PlayedBy);
                    };

                    if (players[1].isPlaying)
                    {
                        this.pieces[i].PlayedBy = 2;
                        bool playerWin = CheckIfPlayerWin(i, this.pieces[i].PlayedBy);
                    };

                    ChangeTurn();
                    return i;
                }
                // Occupied by a piece
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

        public bool CheckIfPlayerWin(int position, int playerNumber)
        {
            bool playerWin = false;
            int count = 0;

            // check vertical
            for (int i = 1; i <= 3; i++)
            {
                bool positionInBound = (position - i) >= 0 && (position - i) < this.pieces.Length;
                
                if (positionInBound  &&
                    this.pieces[position - i] != null &&
                    this.pieces[position - i].PlayedBy == playerNumber)
                {
                    count++;
                    continue;
                }

                break;
            }

            if (count == 3) playerWin = true;

            return playerWin;

        }


    }
}
