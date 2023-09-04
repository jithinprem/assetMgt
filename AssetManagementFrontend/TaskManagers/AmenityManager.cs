using AssetManagement.DTO;
using AssetManagementFrontend.HttpHandler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementFrontend.TaskManagers
{
    public class AmenityManager
    {
        HttpRequestHandler handler = new HttpRequestHandler();

        public async Task AddAminity() {
            AmenityDto amenityDto = new AmenityDto();

            Console.WriteLine("---------------Add Aminity--------------");

            Console.WriteLine("Amenity Name :");
            amenityDto.AmenityName = Console.ReadLine();

            string amenityDtoJson = JsonConvert.SerializeObject(amenityDto);
            handler.HttpPost("Amenity/Add", amenityDtoJson);

        }
        
    }
}
