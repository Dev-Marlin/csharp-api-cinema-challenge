using api_cinema_challenge.Data;
using api_cinema_challenge.Models;
using api_cinema_challenge.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace api_cinema_challenge.Repositories
{
    public class Repository : IRepository
    {
        private CinemaContext _db;

        public Repository(CinemaContext db)
        {
            _db = db;
        }


        // Customers
        public async Task<Customer> CreateCustomer(PostCustomer postcustomer)
        {
            Customer customer = new Customer()
            {
                Name = postcustomer.Name,
                Phone = postcustomer.Phone,
                Email = postcustomer.Email,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _db.Customers.AddAsync(customer);
            await _db.SaveChangesAsync();

            return customer;
        }
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _db.Customers.ToListAsync();
        }
        public async Task<Customer> UpdateCustomer(int id, PutCustomer putCustomer)
        {
            Customer costumerToUpdate = await _db.Customers.FirstAsync(x => x.Id == id);
            var entity = _db.Customers.Update(costumerToUpdate).Entity;

            if(putCustomer.Name != null)
            {
                entity.Name = putCustomer.Name;
            }

            if(putCustomer.Email != null)
            {
                entity.Email = putCustomer.Email;
            }

            if (putCustomer.Phone != null)
            {
                entity.Phone = putCustomer.Phone;
            }

            entity.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();

            return costumerToUpdate;
        }
        public async Task<Customer> DeleteCustomer(int id)
        {
            Customer deletedCustomer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            _db.Customers.Remove(deletedCustomer);
            await _db.SaveChangesAsync();

            return deletedCustomer;
        }


        // Movies
        public async Task<Movie> CreateMovie(PostMovie postMovie)
        {
            Movie movie = new Movie()
            {
                Title = postMovie.Title,
                Rating = postMovie.Rating,
                Description = postMovie.Description,
                RunTimeMins = postMovie.RunTimeMins,
                Screenings = postMovie.Screenings,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
            };

            await _db.Movies.AddAsync(movie);
            await _db.SaveChangesAsync();

            return movie;
        }
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _db.Movies.ToListAsync();
        }
        public async Task<Movie> UpdateMovie(int id, PutMovie putMovie)
        {
            Movie movieToUpdate = await _db.Movies.FirstOrDefaultAsync(x => x.Id==id);
            var entity =  _db.Movies.Update(movieToUpdate).Entity;

            if(putMovie.Title != null)
            { 
                entity.Title = putMovie.Title; 
            }

            if(putMovie.Description != null) 
            { 
                entity.Description = putMovie.Description; 
            }

            if(putMovie.Rating != null)
            {
                entity.Rating = putMovie.Rating;
            }

            if (putMovie.RunTimeMins != null)
            {
                entity.RunTimeMins = (int)putMovie.RunTimeMins;
            }

            entity.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();

            return movieToUpdate;
        }
        public async Task<Movie> DeleteMovie(int id)
        {
            Movie movieToDelete = await _db.Movies.FirstOrDefaultAsync(y => y.Id==id);
            _db.Movies.Remove(movieToDelete);
            await _db.SaveChangesAsync();

            return movieToDelete;
        }


        // Screenings
        public async Task<Screening> CreateScreening(PostScreening postScreening, int movieId)
        {
            Screening screening = new Screening()
            {
                MovieId = movieId,
                ScreenNumber = postScreening.ScreenNumber,
                Capacity = postScreening.Capacity,
                StartsAt = postScreening.StartsAt,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _db.Screenings.AddAsync(screening);
            await _db.SaveChangesAsync();

            return screening;
        }
        public async Task<IEnumerable<Screening>> GetScreenings(int movieId)
        {
            return await _db.Screenings.Where(x => x.MovieId == movieId).ToListAsync();
        }

        // Tickets
        public async Task<Ticket> BookATicket(PostTicket postTicket)
        {
            Ticket ticket = new Ticket()
            {
                numSeats = postTicket.numSeats,
                CustomerId = postTicket.CustomerId,
                ScreeningId = postTicket.ScreeningId,
                UpdatedAt= DateTime.UtcNow,
                CreatedAt= DateTime.UtcNow,
            };

            await _db.Tickets.AddAsync(ticket);
            await _db.SaveChangesAsync();

            return ticket;
        }

        public async Task<IEnumerable<Ticket>> GetTickets()
        {
            return await _db.Tickets.ToListAsync();
        }
    }
}
