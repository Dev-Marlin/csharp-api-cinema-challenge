using api_cinema_challenge.Repositories;
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
        }


        // Customer endpoints
        public static async Task<IResult> CreateCustomer(IRepository repo)
        {
            return TypedResults.Ok();
        }
        public static async Task<IResult> GetCustomers(IRepository repo)
        {
            return TypedResults.Ok();
        }
        public static async Task<IResult> UpdateCustomer(IRepository repo,int id)
        {
            return TypedResults.Ok();
        }
        public static async Task<IResult> DeleteCustomer(IRepository repo,int id)
        {
            return TypedResults.Ok();
        }


        // Movie endpoints

        public static async Task<IResult> CreateMovie(IRepository repo)
        {
            return TypedResults.Ok();
        }
        public static async Task<IResult> GetMovies(IRepository repo)
        {
            return TypedResults.Ok();
        }
        public static async Task<IResult> UpdateMovie(IRepository repo,int id)
        {
            return TypedResults.Ok();
        }
        public static async Task<IResult> DeleteMovie(IRepository repo,int id)
        {
            return TypedResults.Ok();
        }


        // Screening endpoints

        public static async Task<IResult> CreateScreening(IRepository repo)
        {
            return TypedResults.Ok();
        }
        public static async Task<IResult> GetScreenings(IRepository repo)
        {
            return TypedResults.Ok();
        }
    }
}
