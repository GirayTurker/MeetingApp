using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UserController : BaseAPIController
{
    //private readonly DBContext _dbContext;
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        //_dbContext = dbContext;
        _userRepository = userRepository;
    }

    //HTTP ENDPOINTS!!

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return Ok(await _userRepository.GetUsersASync());

        //return users; //200 Ok Response
    }

    [HttpGet("{username}")] //api/user/2

    public async Task<ActionResult<AppUser>> GetUser(string username)
    {
        return await _userRepository.GetByUserNameASync(username);
    }
}
