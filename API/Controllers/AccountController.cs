using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace API.Controllers;

public class AccountController:BaseAPIController
{
    private readonly DBContext _dbContext;
    public AccountController(DBContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost("register")] //api/account/register

    public async Task<ActionResult<AppUser>> Register(RegisterDTO registerDTO)
    {
        if(await UserExist(registerDTO.UserName))
        {
            return BadRequest("User name is exist");
        }

        using var hmac = new HMACSHA512();

        var user = new AppUser
        {
            UserName = registerDTO.UserName.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
            PasswordSalt = hmac.Key
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AppUser>> Login(LoginDTO loginDTO)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(
            option => option.UserName == loginDTO.Username);

            if(user == null)
            {
                return Unauthorized("Invalid Username");
            }

        using var hmac = new HMACSHA512(user.PasswordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

        for (int i=0; computedHash.Length>i; i++)
        {
            if(computedHash[i] != user.PasswordHash[i])
            {
                return Unauthorized("Invalid Password");
            }
        }

        return user;
    }

    private async Task<bool>UserExist(string username)
    {
        return await _dbContext.Users.AnyAsync(user => user.UserName == username.ToLower());
    }
}
