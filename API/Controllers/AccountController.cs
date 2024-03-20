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

    private async Task<bool>UserExist(string username)
    {
        return await _dbContext.Users.AnyAsync(user => user.UserName == username.ToLower());
    }

}
