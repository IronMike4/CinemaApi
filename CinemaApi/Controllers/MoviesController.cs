using CinemaApi.Data;
using CinemaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MoviesController : ControllerBase
  {
    private CinemaDBContext _dbContext;

    public MoviesController(CinemaDBContext dbContext)
    {
      _dbContext = dbContext;
    }




    // GET: api/<MoviesController>
    [HttpGet]
    public IActionResult Get()
    {
      return Ok(_dbContext.Movies);
      //return _dbContext.Movies;
      //return StatusCode(StatusCodes.Status200OK);
    }

    // GET api/<MoviesController>/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      var movie = _dbContext.Movies.Find(id);
      if (movie == null)
      {
        return NotFound("No record found against this Id");
      }
      return Ok(movie);
    }

    // POST api/<MoviesController>
    [HttpPost]
    public IActionResult Post([FromBody] Movie movieObj)
    {
      _dbContext.Movies.Add(movieObj);
      _dbContext.SaveChanges();
      return StatusCode(StatusCodes.Status201Created);
    }

    // PUT api/<MoviesController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Movie movieObj)
    {
      var movie = _dbContext.Movies.Find(id);
      if (movie == null)
      {
        return NotFound("No record found against this Id");
      }
      else
      {
        movie.Name = movieObj.Name;
        movie.Language = movieObj.Language;
        _dbContext.SaveChanges();
        return Ok("Record updated successfully");
      }
    }

    // DELETE api/<MoviesController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var movie = _dbContext.Movies.Find(id);
      if (movie == null)
      {
        return NotFound("No record found against this Id");
      }
      else
      {
        _dbContext.Movies.Remove(movie);
        _dbContext.SaveChanges();
        return Ok("Record deleted");
      }
    }
  }
}
