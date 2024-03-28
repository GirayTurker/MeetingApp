
using API;
using API.Extensions;

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

app.Run();
