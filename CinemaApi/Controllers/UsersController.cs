using CinemaApi.Data;
using CinemaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CinemaApi.Controllers
{
  [Route("api/[controller]/[action]")]
  public class UsersController : ControllerBase
  {
    private CinemaDBContext _dbContext;
    public UsersController(CinemaDBContext dBContext)
    {
      _dbContext = dBContext;
    }

    [HttpPost]
    public IActionResult Register([FromBody] User user)
    {
     var userWithSameEmail =  _dbContext.Users.Where(u => u.Email == user.Email).SingleOrDefault();
      if (userWithSameEmail != null)
      {
        return BadRequest("User with the same email already exists");
      }
      var userObj = new User 
      {
        Name = user.Name,
        Email = user.Email,
        Password = user.Password,
        Role = "Users"
      };
      _dbContext.Users.Add(userObj);
      _dbContext.SaveChanges();
      return StatusCode(StatusCodes.Status201Created);
    }

  }
}
