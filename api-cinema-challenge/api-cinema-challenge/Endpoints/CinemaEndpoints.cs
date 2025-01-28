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
    }
}
