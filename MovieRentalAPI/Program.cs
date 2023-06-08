
using Microsoft.EntityFrameworkCore;
using MovieRentalAPI;
using MovieRentalAPI.Interface;
using MovieRentalAPI.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<VideoShopContext>
    (options =>
    options.UseSqlServer(builder.Configuration["GetConnectionString:DefaultConnection"]));

builder.Services.AddControllers();

builder.Services.AddTransient<IMovies, MoviesService>();
builder.Services.AddTransient<ICustomer, CustomerService>();
builder.Services.AddTransient<IRentals, RentalsService>();
builder.Services.AddTransient<IRentalDetails, RentalDetailsService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();
app.MapControllers();
app.Run();


