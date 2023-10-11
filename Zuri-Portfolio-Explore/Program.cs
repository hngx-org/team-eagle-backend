using Microsoft.EntityFrameworkCore;
using Zuri_Portfolio_Explore.Data;
using Zuri_Portfolio_Explore.Extensions;
using Zuri_Portfolio_Explore.Repository.Interfaces;
using Zuri_Portfolio_Explore.Repository.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DevelopmentConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseNpgsql(connectionString));
builder.Services.AddScoped<IPortfolioService, PortfolioService>();

var app = builder.Build();
app.ConfigureExceptionHandler();
app.UseSwagger();
app.UseSwaggerUI();


// using (var scope = app.Services.CreateScope())
// {
//     var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//     dataContext.Database.Migrate();
//     SeedDB.Initialize(dataContext);
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
