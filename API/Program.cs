
using API.Data;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Extensions Folder
builder.Services.AddAppServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.

/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseHttpsRedirection();

//Angular part (Config the HTTP request pipeline)
app.UseCors(option => option.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

//Auth middleware
app.UseAuthentication(); // Ask for valid token
app.UseAuthorization();  // What Auth user allowed to do

app.MapControllers();

app.Run();
