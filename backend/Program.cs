using backend.Data;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the DB context. using in memory data base (in the future we can convert this to a real SQL server database)
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("HoursReporting"));

// hadnling the repositories DI. Using scoped lifetime which means it's created once per request.
builder.Services.AddScoped<IReportsRepository, ReportsRepository>();

// TBD - check the meaning
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// TBD - was part of the template. check if it's needed
app.UseHttpsRedirection();

app.UseCors(policy =>
policy.AllowAnyMethod()
.AllowAnyHeader()
// Allow any origin for the beginning (later we will limit that to specific url)
.SetIsOriginAllowed(origin => true));
// only for the future when implementing authentication
//.AllowCredentials



// TBD - was part of the template. check if it's needed
app.UseAuthorization();

// TBD - check the meaning
app.MapControllers();

// TBD - check the meaning
app.Run();
