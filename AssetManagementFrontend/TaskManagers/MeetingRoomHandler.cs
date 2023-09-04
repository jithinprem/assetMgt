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
    public class MeetingRoomHandler
    {
        HttpRequestHandler handler = new HttpRequestHandler();
        public async Task AddMeetingRoom()
        {
            MeetingRoomDto meetingRoomDto = new MeetingRoomDto();

            Console.WriteLine("---------------Add Meeting Room--------------");

            Console.WriteLine("Facility Id :");
            meetingRoomDto.FacilityId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Seating Capacity : ");
            meetingRoomDto.Chairs = Convert.ToInt32(Console.ReadLine());

            string meetingRoomDtoJson = JsonConvert.SerializeObject(meetingRoomDto);
            var result = handler.HttpPost("MeetingRoom/Add", meetingRoomDtoJson);

        }
    }
}
