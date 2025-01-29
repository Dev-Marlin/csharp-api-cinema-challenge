namespace api_cinema_challenge.ViewModels
{
    public class GetMovie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int RunTimeMins { get; set; }
        public string Rating { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
