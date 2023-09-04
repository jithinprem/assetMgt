using AssetManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Data
{
    public class SeatManagementDbContext : DbContext
    {
        public DbSet<Allocation> Allocations { get; set; }
        public DbSet<Amenity> Amenitys { get; set; }
        public DbSet<AssetLookup> AssetLookups { get; set; }
        public DbSet<BuildingLookup> BuildingLookups { get; set; }
        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<CityLookup> CityLookups { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<MeetingRoom> MeetingRooms { get; set; }
        public DbSet<RoomToAmenityMap> RoomToAmenityMaps { get; set; }
        public DbSet<Seat> Seats { get; set; }

        public SeatManagementDbContext(DbContextOptions<SeatManagementDbContext> options) : base(options)
        {

        }




    }
}
