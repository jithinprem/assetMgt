using AssetManagement.Data;
using AssetManagement.Model;
using AssetManagement.Service;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<SeatManagementDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IRepository<Allocation>, AssetRepository <Allocation>>();
            builder.Services.AddScoped<IRepository<Facility>, AssetRepository<Facility>>();
            builder.Services.AddScoped<IRepository<Seat>, AssetRepository<Seat>>();
            builder.Services.AddScoped<IRepository<MeetingRoom>, AssetRepository<MeetingRoom>>();
            builder.Services.AddScoped<IRepository<Cabin>, AssetRepository<Cabin>>();
            builder.Services.AddScoped<IRepository<RoomToAmenityMap>, AssetRepository<RoomToAmenityMap>>();
            builder.Services.AddScoped<IRepository<Employee>, AssetRepository<Employee>>();
            builder.Services.AddScoped<IRepository<Amenity>, AssetRepository<Amenity>>();
            builder.Services.AddScoped<IRepository<BuildingLookup>, AssetRepository<BuildingLookup>>();
            builder.Services.AddScoped<IRepository<CityLookup>, AssetRepository<CityLookup>>();



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
}