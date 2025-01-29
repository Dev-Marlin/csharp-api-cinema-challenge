using api_cinema_challenge.Models;
using api_cinema_challenge.ViewModels;

namespace api_cinema_challenge.Repositories
{
    public interface IRepository
    {
        /*
        cinema.MapPost("/customer/create", CreateCustomer);
            cinema.MapGet("/customer/all", GetCustomers);
            cinema.MapPut("/customer/update/{id}", UpdateCustomer);
            cinema.MapDelete("/customer/delete/{id}", DeleteCustomer);

            cinema.MapPost("/movie/create", CreateMovie);
            cinema.MapGet("/movie/all", GetMovies);
            cinema.MapPut("/movie/update/{id}", UpdateMovie);
            cinema.MapDelete("/movie/delete/{id}", DeleteMovie);

            cinema.MapPost("/screening/create", CreateScreening);
            cinema.MapGet("/screening/all", GetScreenings);*/

        public Task<Customer> CreateCustomer(Customer customer);
        public Task<IEnumerable<Customer>> GetCustomers();
        public Task<Customer> UpdateCustomer(int id, PostCustomer postCustomer);
        public Task<Customer> DeleteCustomer(int id);


        public Task<Movie> CreateMovie(Movie movie);
        public Task<IEnumerable<Movie>> GetMovies();
        public Task<Movie> UpdateMovie(int id, PostMovie postMovie);
        public Task<Movie> DeleteMovie(int id);


        public Task<Screening> CreateScreening(Screening screening);
        public Task<IEnumerable<Screening>> GetScreeings();
    }
}
