
using API.Data;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//DBContext Injection
builder.Services.AddDbContext<DBContext>(option =>
{
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Angular part
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
/*
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
*/

//Injection of Token Service
builder.Services.AddScoped<ITokenService,TokenService>();

//Injection of Auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options=>
{
   options.TokenValidationParameters = new TokenValidationParameters
   {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.
        UTF8.GetBytes(builder.Configuration["TokenKey"])),
        ValidateIssuer = false,
        ValidateAudience = false
   }; 
});

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
