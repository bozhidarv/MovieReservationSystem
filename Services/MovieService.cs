using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieReservationSystem.Data;
using MovieReservationSystem.Exceptions;
using MovieReservationSystem.Models;

namespace MovieReservationSystem.Services;

public class MovieService(ILogger<MovieService> logger, MovieTicketContext context)
{
    public List<Movie> GetAllMovies()
    {
        var movie = from m in context.Set<Movie>()
                    select m;

        return [.. movie];
    }

    public Movie GetMovieById(long id)
    {
        var movie = context.Movies.Where(m => m.Id == id);

        if (movie.IsNullOrEmpty())
        {
            throw new NotFoundException($"Movie with id {id} not found");
        }

        return movie.First();
    }

    public long CreateMovie(Movie movie)
    {
        var movieEntry = context.Movies.Add(movie);
        context.SaveChanges();
        return movieEntry.Entity.Id;
    }

    public void UpdateMovie(long id, Movie newMovie)
    {
        var movie = GetMovieById(id);

        context.Entry(movie).CurrentValues.SetValues(newMovie);
        context.Entry(movie).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void DeleteMovie(long id)
    {
        var movie = context.Movies.Find(id);
        if (movie == null)
        {
            throw new BadRequestException($"Movie with id {id} not found");
        }

        context.Movies.Remove(movie);
        context.SaveChanges();
    }
}
