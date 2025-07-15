namespace Interview.MovieBookingSystem;

public class MovieController
{
    public Dictionary<string, Movie> Movies { get; set; } = new Dictionary<string, Movie>();
    public List<Movie> MovieList { get; set; } = new List<Movie>();
}