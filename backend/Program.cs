using backend.Data;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the DB context. using in memory data base (in the future we can convert this to a real SQL server database)
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("HoursReporting"));

// hadnling the repositories DI. Using scoped lifetime which means it's created once per request.
builder.Services.AddScoped<IReportsRepository, ReportsRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
