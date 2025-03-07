﻿using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class Seed
{
    public static async Task SeedUsers(DBContext context)
    {
        //if we have any user exist
        if(await context.Users.AnyAsync())
        {
            return;
        }

        //Get users from defined json file
        var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");

        //All property names in json file will start with UpperCase
        var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

        //Deserialize into AppUser
        var users = JsonSerializer.Deserialize<List<AppUser>>(userData, options);

        //Generate password for users (we registring users that is why !!!!)
        foreach(var user in users)
        {
            using var hmac = new HMACSHA512();

            user.UserName = user.UserName.ToLower();

            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));

            user.PasswordSalt = hmac.Key;

            context.Users.Add(user);
        }

        await context.SaveChangesAsync();
    }
}
