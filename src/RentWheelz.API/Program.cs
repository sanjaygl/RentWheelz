using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using RentWheelz.Database;
using RentWheelz.Service;
using RentWheelz.Service.Repositories;
using RentWheelz.ViewModel.Validators;

namespace RentWheelz.API;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        builder.Services.AddValidatorsFromAssemblyContaining<LoginModelValidator>();

        builder.Services.AddDbContext<RentWheelzDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Register the UserRepository and UserService
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();

        // Register the CarRepository and CarService
        builder.Services.AddScoped<ICarRepository, CarRepository>();
        builder.Services.AddScoped<ICarService, CarService>();

        // Register the BookingRepository and BookingService
        builder.Services.AddScoped<IBookingRepository, BookingRepository>();
        builder.Services.AddScoped<IBookingService, BookingService>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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
    }
}
