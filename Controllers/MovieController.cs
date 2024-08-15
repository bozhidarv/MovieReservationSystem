using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieReservationSystem.Data;
using MovieReservationSystem.Exceptions;
using MovieReservationSystem.Models;
using MovieReservationSystem.Services;

namespace MovieReservationSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController(ILogger<HealthController> logger, MovieService movieService) : ControllerBase
{
    private readonly ILogger<HealthController> _logger = logger;

    [HttpGet(Name = "GetMovies")]
    public IResult Get()
    {
        var movies = movieService.GetAllMovies();
        return Results.Ok(movies);
    }

    [HttpGet("{id:long}", Name = "GetMovie")]
    public IResult Get(long id)
    {
        var movie = movieService.GetMovieById(id);
        return Results.Ok(movie);
    }

    [HttpPost(Name = "CreateMovie")]
    public IResult Post(Movie movie)
    {
        var id = movieService.CreateMovie(movie);
        return Results.CreatedAtRoute("GetMovie", new {id}, movie);
    }

    [HttpPut("{id:long}", Name = "UpdateMovie")]
    public IResult Put(long id, Movie newMovie)
    {
        try
        {
            movieService.UpdateMovie(id, newMovie);
            return Results.CreatedAtRoute("GetMovie", new {id});
        }
        catch (NotFoundException e)
        {
            throw new BadRequestException(e.Message);
        }
    }

    [HttpDelete("{id:long}", Name = "DeleteMovie")]
    public IResult Delete(long id)
    {
        movieService.DeleteMovie(id);
        return Results.NoContent();
    }
}