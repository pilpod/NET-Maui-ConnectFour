
namespace ConnectFour.Models
{
    public class Piece
    {
        public bool IsOccupied { get; set; }

        public Piece()
        {
            this.IsOccupied = false;
        }
    }
}
