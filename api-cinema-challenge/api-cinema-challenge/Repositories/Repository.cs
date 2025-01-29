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
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            await _db.Customers.AddAsync(customer);
            await _db.SaveChangesAsync();

            return customer;
        }
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _db.Customers.ToListAsync();
        }
        public async Task<Customer> UpdateCustomer(int id, PostCustomer postCustomer)
        {
            Customer costumerToUpdate = await _db.Customers.FirstAsync(x => x.Id == id);
            var entity = _db.Customers.Update(costumerToUpdate).Entity;

            if(postCustomer.Name != null)
            {
                entity.Name = postCustomer.Name;
            }

            if(postCustomer.Email != null)
            {
                entity.Email = postCustomer.Email;
            }

            if (postCustomer.Phone != null)
            {
                entity.Phone = postCustomer.Phone;
            }

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
        public async Task<Movie> CreateMovie(Movie movie)
        {
            await _db.Movies.AddAsync(movie);
            await _db.SaveChangesAsync();

            return movie;
        }
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _db.Movies.ToListAsync();
        }
        public async Task<Movie> UpdateMovie(int id, PostMovie postMovie)
        {
            Movie movieToUpdate = await _db.Movies.FirstOrDefaultAsync(x => x.Id==id);
            var entity =  _db.Movies.Update(movieToUpdate).Entity;

            if(postMovie.Title != null)
            { 
                entity.Title = postMovie.Title; 
            }

            if(postMovie.Description != null) 
            { 
                entity.Description = postMovie.Description; 
            }

            if(postMovie.Rating != null)
            {
                entity.Rating = (int)postMovie.Rating;
            }

            if (postMovie.RunTimeMins != null)
            {
                entity.RunTimeMins = (int)postMovie.RunTimeMins;
            }

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
        public async Task<Screening> CreateScreening(PostScreening postScreening)
        {
            Screening screening = new Screening()
            {
                MovieId = postScreening.MovieId,
                ScreenNumber = postScreening.ScreenNumber,
                Capacity = postScreening.Capacity,
                StartsAt = postScreening.StartsAt,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            await _db.Screenings.AddAsync(screening);
            await _db.SaveChangesAsync();

            return screening;
        }
        public async Task<IEnumerable<Screening>> GetScreeings(int movieId)
        {
            return await _db.Screenings.ToListAsync();
        }
    }
}
