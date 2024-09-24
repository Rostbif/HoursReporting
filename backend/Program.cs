using backend.Data;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the DB context. using in memory data base (in the future we can convert this to a real SQL server database)
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("HoursReporting"));

// handling the repositories Dependency injection. Using scoped lifetime which means it's created once per request.
builder.Services.AddScoped<IReportsRepository, ReportsRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// We need that In order to accept requests from the client which is in another URL.
app.UseCors(policy =>
policy.AllowAnyMethod()
.AllowAnyHeader()
// Allow any origin for the beginning (later we will limit that to specific url)
.SetIsOriginAllowed(origin => true));
//.WithOrigins("http://localhost:5173"));
// only for the future when implementing authentication
//.AllowCredentials


// No need for now. only for the future when implementing authorization
// app.UseAuthorization();

app.MapControllers();

app.Run();
