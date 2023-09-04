using AssetManagement.Data;
using AssetManagement.DTO;
using AssetManagement.Model;

namespace AssetManagement.Service
{
    public class AmenityService
    {
        private readonly IRepository<Amenity> _repository;

        public AmenityService(IRepository<Amenity> repository) {
            _repository = repository;
        }
        public void AddAmenity(AmenityDto amenityDto) {
            _repository.Add(new Amenity { AmenityName = amenityDto.AmenityName });
        }
    }
}
