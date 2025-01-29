using api_cinema_challenge.Models;
using api_cinema_challenge.Repositories;
using api_cinema_challenge.ViewModels;
using Microsoft.AspNetCore.Http;

namespace api_cinema_challenge.Endpoints
{
    public static class CinemaEndpoints
    {
        public static void ConfigureEndpoints(this WebApplication app)
        {
            var cinema = app.MapGroup("/cinema");

            cinema.MapPost("/customer/create", CreateCustomer);
            cinema.MapGet("/customer/all", GetCustomers);
            cinema.MapPut("/customer/update/{id}", UpdateCustomer);
            cinema.MapDelete("/customer/delete/{id}", DeleteCustomer);

            cinema.MapPost("/movie/create", CreateMovie);
            cinema.MapGet("/movie/all", GetMovies);
            cinema.MapPut("/movie/update/{id}", UpdateMovie);
            cinema.MapDelete("/movie/delete/{id}", DeleteMovie);

            cinema.MapPost("/screening/create", CreateScreening);
            cinema.MapGet("/screening/all", GetScreenings);

            cinema.MapPost("/ticket/book", BookATicket);
            cinema.MapGet("/ticket/all", GetTickets);
        }


        // Customer endpoints
        
        public static async Task<IResult> CreateCustomer(IRepository repo, PostCustomer postCustomer)
        {
            Customer createdCustomer = await repo.CreateCustomer(postCustomer);

            GetCustomer getCustomer = new GetCustomer()
            {
                Id = createdCustomer.Id,
                Name = createdCustomer.Name,
                Phone = createdCustomer.Phone,
                Email = createdCustomer.Email,
                CreatedAt = createdCustomer.CreatedAt,
                UpdatedAt = createdCustomer.UpdatedAt,
            };

            return TypedResults.Created("",getCustomer);
        }
        public static async Task<IResult> GetCustomers(IRepository repo)
        {
            IEnumerable<Customer> customerList = await repo.GetCustomers();

            List<GetCustomer> getCustomerList = new List<GetCustomer>();

            foreach (Customer customer in customerList)
            {
                GetCustomer getCustomer = new GetCustomer()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Phone = customer.Phone,
                    Email = customer.Email,
                    CreatedAt = customer.CreatedAt,
                    UpdatedAt = customer.UpdatedAt,
                };

                getCustomerList.Add(getCustomer);
            }

            return TypedResults.Ok(getCustomerList);
        }
        public static async Task<IResult> UpdateCustomer(IRepository repo,int id, PutCustomer putCustomer)
        {
            Customer updatedCustomer = await repo.UpdateCustomer(id, putCustomer);

            GetCustomer getCustomer = new GetCustomer()
            {
                Id = updatedCustomer.Id,
                Name = updatedCustomer.Name,
                Phone = updatedCustomer.Phone,
                Email = updatedCustomer.Email,
                CreatedAt = updatedCustomer.CreatedAt,
                UpdatedAt = updatedCustomer.UpdatedAt,
            };

            return TypedResults.Created("", getCustomer);
        }
        public static async Task<IResult> DeleteCustomer(IRepository repo,int id)
        {
            Customer deletedCustomer = await repo.DeleteCustomer(id);

            GetCustomer getCustomer = new GetCustomer()
            {
                Id = deletedCustomer.Id,
                Name = deletedCustomer.Name,
                Phone = deletedCustomer.Phone,
                Email = deletedCustomer.Email,
                CreatedAt = deletedCustomer.CreatedAt,
                UpdatedAt = deletedCustomer.UpdatedAt,
            };

            return TypedResults.Ok(getCustomer);
        }


        // Movie endpoints

        public static async Task<IResult> CreateMovie(IRepository repo, PostMovie postMovie)
        {
            Movie createdMovie = await repo.CreateMovie(postMovie);

            GetMovie getMovie = new GetMovie()
            {
                Id = createdMovie.Id,
                Title = createdMovie.Title,
                Description = createdMovie.Description,
                Rating = createdMovie.Rating,
                RunTimeMins = createdMovie.RunTimeMins,
                CreatedAt= createdMovie.CreatedAt,
                UpdatedAt= createdMovie.UpdatedAt,
            };

            return TypedResults.Created("", getMovie);
        }
        public static async Task<IResult> GetMovies(IRepository repo)
        {
            IEnumerable<Movie> movieList = await repo.GetMovies();

            List<GetMovie> getMovieList = new List<GetMovie>();

            foreach (Movie movie in movieList)
            {
                GetMovie getMovie = new GetMovie()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    Rating = movie.Rating,
                    RunTimeMins = movie.RunTimeMins,
                    CreatedAt = movie.CreatedAt,
                    UpdatedAt = movie.UpdatedAt,
                };

                getMovieList.Add(getMovie);
            }

            return TypedResults.Ok(getMovieList);
        }
        public static async Task<IResult> UpdateMovie(IRepository repo,int id, PutMovie putMovie)
        {
            Movie updatedMovie = await repo.UpdateMovie(id, putMovie);

            GetMovie getMovie = new GetMovie()
            {
                Id = updatedMovie.Id,
                Title = updatedMovie.Title,
                Description = updatedMovie.Description,
                Rating = updatedMovie.Rating,
                RunTimeMins = updatedMovie.RunTimeMins,
                CreatedAt = updatedMovie.CreatedAt,
                UpdatedAt = updatedMovie.UpdatedAt,
            };

            return TypedResults.Created("", getMovie);
        }
        public static async Task<IResult> DeleteMovie(IRepository repo,int id)
        {
            Movie deletedMovie = await repo.DeleteMovie(id);

            GetMovie getMovie = new GetMovie()
            {
                Id = deletedMovie.Id,
                Title = deletedMovie.Title,
                Description = deletedMovie.Description,
                Rating = deletedMovie.Rating,
                RunTimeMins = deletedMovie.RunTimeMins,
                CreatedAt = deletedMovie.CreatedAt,
                UpdatedAt = deletedMovie.UpdatedAt,
            };

            return TypedResults.Ok(getMovie);
        }


        // Screening endpoints

        public static async Task<IResult> CreateScreening(IRepository repo, PostScreening postScreening, int movieId)
        {
            Screening createdScreening = await repo.CreateScreening(postScreening, movieId);

            GetScreening getScreening = new GetScreening()
            {
                Id = createdScreening.Id,
                ScreenNumber = createdScreening.ScreenNumber,
                Capacity = createdScreening.Capacity,
                StartsAt = createdScreening.StartsAt,
                CreatedAt = createdScreening.CreatedAt,
                UpdatedAt= createdScreening.UpdatedAt,
            };

            return TypedResults.Created("",getScreening);
        }
        public static async Task<IResult> GetScreenings(IRepository repo, int movieId)
        {
            IEnumerable<Screening> screeningList = await repo.GetScreenings(movieId);

            List<GetScreening> getScreeningList = new List<GetScreening>();

            foreach(Screening screening in screeningList)
            {
                GetScreening getScreening = new GetScreening()
                {
                    Id = screening.Id,
                    ScreenNumber = screening.ScreenNumber,
                    Capacity = screening.Capacity,
                    StartsAt = screening.StartsAt,
                    CreatedAt = screening.CreatedAt,
                    UpdatedAt = screening.UpdatedAt,
                };

                getScreeningList.Add(getScreening);
            }

            return TypedResults.Ok(getScreeningList);
        }


        // Ticket endpoints

        public static async Task<IResult> BookATicket(IRepository repo, PostTicket postTicket)
        {
            Ticket createdTicket = await repo.BookATicket(postTicket);

            GetTicket getTicket = new GetTicket()
            {
                CustomerId = createdTicket.CustomerId,
                ScreeningId = createdTicket.ScreeningId,
                numSeats = createdTicket.numSeats,
                CreatedAt = createdTicket.CreatedAt,
                UpdatedAt = createdTicket.UpdatedAt,
            };

            return TypedResults.Created("",getTicket);
        }

        public static async Task<IResult> GetTickets(IRepository repo)
        {
            IEnumerable<Ticket> ticketList = await repo.GetTickets();

            List<GetTicket> getTicketList = new List<GetTicket>();

            foreach (Ticket ticket in ticketList)
            {
                GetTicket getTicket = new GetTicket()
                {
                    CustomerId = ticket.CustomerId,
                    ScreeningId = ticket.ScreeningId,
                    numSeats = ticket.numSeats,
                    CreatedAt = ticket.CreatedAt,
                    UpdatedAt = ticket.UpdatedAt,
                };

                getTicketList.Add(getTicket);
            }
            return TypedResults.Ok(getTicketList);
        }
    }
}
