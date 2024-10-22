using MongoDB.Driver;
using MoviesApp.Models;

namespace Movies.Models
{
    public class MovieDbContext
    {
        private readonly IMongoDatabase _database;

        // Constructor to inject connection string and database name
        public MovieDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDb");
            var databaseName = configuration.GetValue<string>("MongoDbSettings:MovieDatabaseName");

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        // Movies collection
        public IMongoCollection<Movie> Movies
        {
            get
            {
                return _database.GetCollection<Movie>("MovieDb");
            }
        }

    }
}
