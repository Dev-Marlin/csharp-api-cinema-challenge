using api_cinema_challenge.Models;
using api_cinema_challenge.ViewModels;

namespace api_cinema_challenge.Repositories
{
    public interface IRepository
    {
        public Task<Customer> CreateCustomer(PostCustomer postCustomer);
        public Task<IEnumerable<Customer>> GetCustomers();
        public Task<Customer> UpdateCustomer(int id, PutCustomer putCustomer);
        public Task<Customer> DeleteCustomer(int id);


        public Task<Movie> CreateMovie(PostMovie postMovie);
        public Task<IEnumerable<Movie>> GetMovies();
        public Task<Movie> UpdateMovie(int id, PutMovie putMovie);
        public Task<Movie> DeleteMovie(int id);


        public Task<Screening> CreateScreening(PostScreening postScreening, int movieId);
        public Task<IEnumerable<Screening>> GetScreenings(int movieId);


        public Task<Ticket> BookATicket(PostTicket postTicket);
        public Task<IEnumerable<Ticket>> GetTickets();
    }
}
