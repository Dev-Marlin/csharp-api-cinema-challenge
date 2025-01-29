using api_cinema_challenge.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace api_cinema_challenge.Data
{
    public class Seeder
    {
        private List<string> firstnames = new List<string>();
        private List<string> lastnames = new List<string>();
        private List<string> emails = new List<string>();
        private List<string> phoneNumbers = new List<string>();

        private List<DateTime> dateTimes = new List<DateTime>();

        // movie data
        private List<string> movieTitles = new List<string>();
        private List<string> movieRatings = new List<string>();
        private List<string> movieDescription = new List<string>();
        public Seeder() {
            InitializeFirstNames();
            InitializeLastNames();
            InitializeEmails();
            InitializeDates();
            InitializePhoneNumbers();

            InitializeMovieTitles();
            InitializeMovieRatings();
            InitializeMovieDescription();

            InitializeMovies();
            InitializeCustomers();
            InitializeScreenings();
            InitializeTickets();
        }

        private void InitializeMovies()
        {
            Random randRating = new Random();
            Random randTitle = new Random();
            Random randDesc = new Random();
            Random randRunTime = new Random();

            for (int i = 1; i < 31; i++)
            {
                Movie movie = new Movie()
                {
                    Id = i,
                    Title = movieTitles[randTitle.Next(movieTitles.Count - 1)],
                    Rating = movieRatings[randRating.Next(movieRatings.Count - 1)],
                    Description = movieDescription[randDesc.Next(movieDescription.Count - 1)],
                    RunTimeMins = randRunTime.Next(120) + 30,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                MovieList.Add(movie);
            }
        }

        private void InitializeCustomers()
        {
            Random randFirstName = new Random();
            Random randLastName = new Random();
            Random randPhoneNumber = new Random();
            Random randMail = new Random();

            for(int i = 1; i < 101; i++)
            {
                string name = String.Concat(firstnames[randFirstName.Next(firstnames.Count - 1)], " " + lastnames[randLastName.Next(lastnames.Count - 1)]);
                Customer customer = new Customer()
                {
                    Id = i,
                    Name = name,
                    Email = String.Concat(name, emails[randMail.Next(emails.Count-1)]),
                    Phone = phoneNumbers[randPhoneNumber.Next(phoneNumbers.Count - 1)],
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                CustomerList.Add(customer);
            }
        }

        public void InitializeScreenings()
        {
            Random randScreeningNbr = new Random();
            Random randCapacity = new Random();
            Random randDate = new Random();
            Random randomMovie = new Random();

            for (int i = 1; i < 61; i++)
            {
                Screening screening = new Screening()
                {
                    Id = i,
                    ScreenNumber = randScreeningNbr.Next(60),
                    Capacity = randCapacity.Next(60) + 20,
                    MovieId = randomMovie.Next(30) + 1,
                    StartsAt = dateTimes[randDate.Next(dateTimes.Count - 1)],
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                ScreeningList.Add(screening);
            }
        }

        public void InitializeTickets()
        {
            Random randScreenId = new Random();
            Random randCustomerId = new Random();
            Random randNumSeats = new Random();

            for (int i = 1; i < 101; i++)
            {
                Ticket ticket = new Ticket()
                {
                    ScreeningId = randScreenId.Next(60) + 1,
                    CustomerId = i,
                    numSeats = randNumSeats.Next(7)+1,
                    CreatedAt= DateTime.UtcNow,
                    UpdatedAt= DateTime.UtcNow
                };

                TicketList.Add(ticket);
            }
        }

        private void InitializeMovieTitles()
        {
            movieTitles.Add("The Shawshank Redemption");
            movieTitles.Add("The Godfather");
            movieTitles.Add("The Dark Knight");
            movieTitles.Add("The Godfather Part II");
            movieTitles.Add("12 Angry Men");
            movieTitles.Add("The Lord of the Rings: The Return of the King");
            movieTitles.Add("The Lord of the Rings: The Fellowship of the Ring");
            movieTitles.Add("Forrest Gump");
            movieTitles.Add("Fight Club");
            movieTitles.Add("Inception");
            movieTitles.Add("The Matrix");
            movieTitles.Add("Interstellar");
            movieTitles.Add("The Silence of the Lambs");
            movieTitles.Add("Saving Private Ryan");
        }

        private void InitializeMovieRatings()
        {
            movieRatings.Add("G");
            movieRatings.Add("PG");
            movieRatings.Add("PG-13");
            movieRatings.Add("R");
        }

        private void InitializeMovieDescription()
        {
            movieDescription.Add("The greatest movie ever made.");
            movieDescription.Add("The movie is about a guy that know another guy and they fight or something");
            movieDescription.Add("Horror movie where every person splits up and thinks its a good idea");
            movieDescription.Add("They are in space trying to survive");
            movieDescription.Add("Superheros that fights villains");
            movieDescription.Add("Small happy people dancing around with a ring");
            movieDescription.Add("This movie is hard to understand");
        }
        private void InitializeFirstNames()
        {
            firstnames.Add("Sofia");
            firstnames.Add("Adrian");
            firstnames.Add("Johannes");
            firstnames.Add("Emma");
            firstnames.Add("Nigel");
            firstnames.Add("Erik");
            firstnames.Add("Karl");
            firstnames.Add("Anna");
            firstnames.Add("Frida");
            firstnames.Add("Bert");
        }

        private void InitializeLastNames()
        {
            lastnames.Add("Davidsson");
            lastnames.Add("Thompson");
            lastnames.Add("White");
            lastnames.Add("Sanchez");
            lastnames.Add("Lewis");
            lastnames.Add("Robinson");
            lastnames.Add("Scott");
            lastnames.Add("Young");
            lastnames.Add("Hill");
            lastnames.Add("Flores");
        }

        private void InitializeDates()
        {
            dateTimes.Add(new DateTime(2024, 5, 1));
            dateTimes.Add(new DateTime(2025, 11, 27));
            dateTimes.Add(new DateTime(2025, 1, 2));
            dateTimes.Add(new DateTime(2024, 3, 14));
            dateTimes.Add(new DateTime(2025, 11, 12));
            dateTimes.Add(new DateTime(2024, 3, 8));
            dateTimes.Add(new DateTime(2024, 7, 29));
            dateTimes.Add(new DateTime(2025, 7, 19));
            dateTimes.Add(new DateTime(2024, 10, 5));
            dateTimes.Add(new DateTime(2024, 12, 3));
        }

        private void InitializeEmails()
        {
            emails.Add("@hotmail.com");
            emails.Add("@live.se");
            emails.Add("@google.com");
            emails.Add("@hotmail.org");
            emails.Add("@outlook.nu");
            emails.Add("@live.com");
            emails.Add("@icloud.com");
            emails.Add("@hotmail.nu");
        }

        private void InitializePhoneNumbers()
        {
            phoneNumbers.Add("+45 42 342 1223");
            phoneNumbers.Add("+30 07 892 5192");
            phoneNumbers.Add("+95 13 403 2392");
            phoneNumbers.Add("+46 09 931 3228");
            phoneNumbers.Add("+20 48 271 3712");
            phoneNumbers.Add("+45 45 992 1563");
            phoneNumbers.Add("+31 07 112 5192");
            phoneNumbers.Add("+76 13 493 2442");
            phoneNumbers.Add("+46 09 221 3788");
            phoneNumbers.Add("+23 87 311 3902");
            phoneNumbers.Add("+45 02 342 0323");
            phoneNumbers.Add("+67 07 292 4392");
            phoneNumbers.Add("+27 13 603 2305");
            phoneNumbers.Add("+44 09 761 7728");
            phoneNumbers.Add("+25 65 271 3742");
            phoneNumbers.Add("+45 42 342 1293");
            phoneNumbers.Add("+60 57 863 5592");
            phoneNumbers.Add("+15 13 433 2312");
            phoneNumbers.Add("+36 09 939 1218");
            phoneNumbers.Add("+28 08 277 3732");
        }

        public List<Customer> CustomerList { get; set; } = [];
        public List<Movie> MovieList { get; set; } = [];
        public List<Screening> ScreeningList { get; set; } = [];
        public List<Ticket> TicketList { get; set; } = [];
    }
}
