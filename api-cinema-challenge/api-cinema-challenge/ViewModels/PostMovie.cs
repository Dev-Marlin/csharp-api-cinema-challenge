using api_cinema_challenge.Models;

namespace api_cinema_challenge.ViewModels
{
    public class PostMovie
    {
        public string Title { get; set; }
        public int RunTimeMins { get; set; }
        public string Rating { get; set; }
        public string Description { get; set; }

        public ICollection<Screening> Screenings { get; set; }
    }
}
