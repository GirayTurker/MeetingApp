using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // api/user
public class UserController : ControllerBase
{
    private readonly DBContext _dbContext;

    public UserController(DBContext dbContext)
    {
        _dbContext = dbContext;
    }

    //HTTP ENDPOINTS!!

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _dbContext.Users.ToListAsync();

        return users; //200 Ok Response
    }

    [HttpGet("{id}")] //api/user/2

    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _dbContext.Users.FindAsync(id);
    }
}
