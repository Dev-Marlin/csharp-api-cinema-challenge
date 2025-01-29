﻿namespace api_cinema_challenge.Models
{
    public class Ticket
    {
        public int ScreeningId { get; set; }
        public int CustomerId { get; set; }
        public int numSeats { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Customer Customer { get; set; }
        public Screening Screening { get; set; }

    }
}
