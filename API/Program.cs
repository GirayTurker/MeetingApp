
using API;
using API.Data;
using API.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Extensions Folder
builder.Services.AddAppServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);


var app = builder.Build();

/*
if(builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
*/

//Middleware Exception Handling Should go top of the HTTP Pipeline!!!!
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
//Angular part 
app.UseCors(option => option.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

//Auth middleware
app.UseAuthentication(); // Ask for valid token
app.UseAuthorization();  // What Auth user allowed to do

app.MapControllers();

// Applying seed data from Seed class===========================
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<DBContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedUsers(context);
}
catch (Exception ex)
{
    var logger = services.GetService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration!!!!");
}
// Applying seed data from Seed class===========================

app.Run();
