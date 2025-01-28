namespace api_cinema_challenge.Models
{
    public class Ticket
    {
        public int ScreeningId { get; set; }
        public int CustomerId { get; set; }
        public float Price { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
