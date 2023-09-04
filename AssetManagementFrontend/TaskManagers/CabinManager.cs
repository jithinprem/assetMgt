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
    public class CabinManager
    {
        HttpRequestHandler handler = new HttpRequestHandler();
        public async Task AddCabin()
        {

            CabinDto cabinDto = new CabinDto();


            Console.WriteLine("---------------Add Cabin--------------");

            Console.WriteLine("Facility Id :");
            cabinDto.FacilityId = Convert.ToInt32(Console.ReadLine());

            string seatDtoJson = JsonConvert.SerializeObject(cabinDto);
            var result = handler.HttpPost("Cabin/Add", seatDtoJson);
        }
    }
}
