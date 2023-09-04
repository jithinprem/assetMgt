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
    public class FacilityManager
    {
        HttpRequestHandler handler = new HttpRequestHandler();

        public async Task AddFacility() {

            // first display all the facilities -> to do

            FacilityDto facilityDto = new FacilityDto();    

            Console.WriteLine("---------------Add Facility--------------");

            Console.WriteLine("Facility Name : ");
            facilityDto.FacilityName = Console.ReadLine();

            Console.WriteLine("Building Name : ");
            facilityDto.BuildingName = Console.ReadLine();

            Console.WriteLine("City Name : ");
            facilityDto.CityName = Console.ReadLine();

            Console.WriteLine("Floor :");
            facilityDto.Floor = Convert.ToInt32(Console.ReadLine());

            string facilityDtoJson = JsonConvert.SerializeObject(facilityDto);
            var result = handler.HttpPost("Facility/Add", facilityDtoJson);


        }
    }
}
