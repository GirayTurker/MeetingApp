using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // api/user
public class UserController: ControllerBase
{
    private readonly DBContext _dbContext;

    public UserController(DBContext dbContext)
    {
        _dbContext = dbContext;
    }

    //HTTP ENDPOINTS!!

    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
       var users = _dbContext.Users.ToList();
       
       return users; //200 Ok Response
    }

    [HttpGet("{id}")] //api/user/2

    public ActionResult<AppUser> GetUser(int id)
    {
        return _dbContext.Users.Find(id);
     
    }

}
