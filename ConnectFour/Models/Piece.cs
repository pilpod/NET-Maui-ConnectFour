
namespace ConnectFour.Models
{
    public class Piece
    {
        public bool IsOccupied { get; set; }
        public int PlayedBy { get; set; }

        public Piece()
        {
            this.IsOccupied = false;
            this.PlayedBy = 0;
        }
    }
}
