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
    public class SeatManager
    {
        HttpRequestHandler handler = new HttpRequestHandler();
        public async Task AddSeat() {

            SeatDto seatDto = new SeatDto();


            Console.WriteLine("---------------Add Seat--------------");

            Console.WriteLine("Facility Id :");
            seatDto.FacilityId = Convert.ToInt32(Console.ReadLine());

            string seatDtoJson = JsonConvert.SerializeObject(seatDto);
            var result = handler.HttpPost("Seat/Add", seatDtoJson);
        }
    }
}
