

using System;

namespace ConnectFour.Models
{
    public class State
    {
        public readonly Player[] players;
        int GameRoundsPlayed;
        public bool GameOver;
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
            GameRoundsPlayed = 0;
            Array.Clear(this.pieces);
        }

        public void EndGame()
        {
            GameOver = true;
            GameRoundsPlayed++;
            Array.Clear(this.pieces);
        }

        public void NewGame()
        {
            GameOver = false;
            players[0].isPlaying = true;
            players[1].isPlaying = false;
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

                        if (playerWin)
                        {
                            players[0].Points++;
                            EndGame();
                        }
                    };

                    if (players[1].isPlaying)
                    {
                        this.pieces[i].PlayedBy = 2;
                        bool playerWin = CheckIfPlayerWin(i, this.pieces[i].PlayedBy);

                        if (playerWin)
                        {
                            players[1].Points++;
                            EndGame();
                        }
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
            int countVertical = 0;
            int countHorizontal = 0;
            int countDiagonalRight = 0;
            int countDiagonalLeft = 0;

            // check vertical
            for (int i = 1; i <= 3; i++)
            {
                bool positionInBound = (position - i) >= 0 && (position - i) < this.pieces.Length;

                if (positionInBound &&
                    this.pieces[position - i] != null &&
                    this.pieces[position - i].PlayedBy == playerNumber)
                {
                    countVertical++;
                    continue;
                }

                break;
            }

            //check horitzontal
            for (int i = 1; i <= 3; i++)
            {
                int neighbornPieceRight = position + i * 6;
                bool positionInBoundRight = neighbornPieceRight >= 0 && neighbornPieceRight < this.pieces.Length;

                int neighbornPieceLeft = position - i * 6;
                bool positionInBoundLeft = neighbornPieceLeft >= 0 && neighbornPieceLeft < this.pieces.Length;

                if (positionInBoundRight || positionInBoundLeft)
                {
                    if (positionInBoundRight &&
                        this.pieces[neighbornPieceRight] != null &&
                        this.pieces[neighbornPieceRight].PlayedBy == playerNumber)
                    {
                        countHorizontal++;
                    }

                    if (positionInBoundLeft &&
                        this.pieces[neighbornPieceLeft] != null &&
                        this.pieces[neighbornPieceLeft].PlayedBy == playerNumber)
                    {
                        countHorizontal++;
                    }
                    continue;
                }

                break;
            }

            // check diagonal right
            for (int i = 1; i <= 3; i++)
            {
                int neighbornPieceDownRight = position + i * 5;
                bool positionInBoundDownRight = neighbornPieceDownRight >= 0 && neighbornPieceDownRight < this.pieces.Length;

                int neighbornPieceUpLeft = position - i * 5;
                bool positionInBoundUpLeft = neighbornPieceUpLeft >= 0 && neighbornPieceUpLeft < this.pieces.Length;


                if (positionInBoundUpLeft || positionInBoundDownRight)
                {
                    if (positionInBoundUpLeft &&
                    this.pieces[neighbornPieceUpLeft] != null &&
                    this.pieces[neighbornPieceUpLeft].PlayedBy == playerNumber) countDiagonalRight++;


                    if (positionInBoundDownRight &&
                        this.pieces[neighbornPieceDownRight] != null &&
                        this.pieces[neighbornPieceDownRight].PlayedBy == playerNumber) countDiagonalRight++;

                    continue;
                }

                break;
            }

            // check diagonal left
            for (int i = 1; i <= 3; i++)
            {
                int neighbornPieceUpRight = position + i * 7;
                bool positionInBoundUpRight = neighbornPieceUpRight >= 0 && neighbornPieceUpRight < this.pieces.Length;

                int neighbornPieceDownLeft = position - i * 7;
                bool positionInBoundDownLeft = neighbornPieceDownLeft >= 0 && neighbornPieceDownLeft < this.pieces.Length;


                if (positionInBoundUpRight || positionInBoundDownLeft)
                {
                    if (positionInBoundUpRight &&
                        this.pieces[neighbornPieceUpRight] != null &&
                        this.pieces[neighbornPieceUpRight].PlayedBy == playerNumber) countDiagonalLeft++;

                    if (positionInBoundDownLeft &&
                        this.pieces[neighbornPieceDownLeft] != null &&
                        this.pieces[neighbornPieceDownLeft].PlayedBy == playerNumber) countDiagonalLeft++;

                    continue;
                }

                break;
            }

            if (countVertical == 3 || countHorizontal == 3 || countDiagonalRight == 3 || countDiagonalLeft == 3) playerWin = true;

            return playerWin;

        }

        public bool CheckIfColumnFull(int column)
        {
            int piecesByColumn = 6;
            bool isFull = false;
            int currentQuantityOfPieces = 0;
            int initIndex = column * piecesByColumn;

            for (int i = initIndex; i < initIndex + piecesByColumn; i++)
            {
                if (pieces[i] != null && pieces[i].IsOccupied) currentQuantityOfPieces++;
            }

            if (currentQuantityOfPieces == piecesByColumn)
            {
                isFull = true;
                return isFull;
            }

            return isFull;
        }


    }
}
