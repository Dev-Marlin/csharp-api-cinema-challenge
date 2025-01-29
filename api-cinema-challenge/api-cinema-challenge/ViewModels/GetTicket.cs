namespace api_cinema_challenge.ViewModels
{
    public class GetTicket
    {
        public int ScreeningId { get; set; }
        public int CustomerId { get; set; }
        public int numSeats { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
