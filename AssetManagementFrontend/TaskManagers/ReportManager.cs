using AssetManagement.DTO;
using AssetManagement.Model;
using AssetManagementFrontend.HttpHandler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementFrontend.TaskManagers
{

    public class ReportManager
    {
        HttpRequestHandler handler = new HttpRequestHandler();

        public void DisplaySeats(List<Seat> seatList) {
            
            Console.WriteLine("SeatId\t| SeatName\t\t\t\t\t| FacilityId");

            foreach (var freeseat in seatList)
            {
                Console.WriteLine($" {freeseat.SeatId} \t | {freeseat.SeatName} |\t\t\t {freeseat.FacilityId}.");
            }
            Console.WriteLine("-------------END---------------");
        }


        public void DisplayCabin(List<Cabin> cabinList)
        {
            Console.WriteLine("CabinId\t| CabinName\t\t\t\t\t| CabinId");

            foreach (var freecabin in cabinList)
            {
                Console.WriteLine($" {freecabin.CabinId} \t | {freecabin.CabinName} |\t\t\t {freecabin.FacilityId}.");
            }
            Console.WriteLine("---------------END-------------");
        }


        public async Task GetFreeSeats() {
            var result = await handler.HttpGet("Seat/FreeSeats");
            List<Seat> allFreeSeats = JsonConvert.DeserializeObject<List<Seat>>(result);

            Console.WriteLine("Free Seats :");
            DisplaySeats(allFreeSeats);
        }

        public async Task FreeSeatByFacility() {
            Console.WriteLine("Enter the Facility Id : ");
            string facilityId = Console.ReadLine();

            var queryParameters = new System.Collections.Generic.Dictionary<string, string>
            {
                { "facilityId", facilityId }
            };
            string queryString = string.Join("&", queryParameters.Select(kv => $"{kv.Key}={kv.Value}"));
            string targetUrl = $"Seat/FreeSeatsByFacility/?{queryString}";


            var result = await handler.HttpGet(targetUrl);
            List<Seat> allFreeSeats = JsonConvert.DeserializeObject<List<Seat>>(result);

            Console.WriteLine("Free Seats In Facility :");
            DisplaySeats(allFreeSeats);
        }

        public async Task FreeCabinByFacility() {
            Console.WriteLine("Enter the Facility Id : ");
            string facilityId = Console.ReadLine();

            var queryParameters = new Dictionary<string, string>
            {
                { "facilityId", facilityId }
            };
            string queryString = string.Join("&", queryParameters.Select(kv => $"{kv.Key}={kv.Value}"));
            string targetUrl = $"Cabin/FreeCabinsByFacility/?{queryString}";

            var result = await handler.HttpGet(targetUrl);
            List<Cabin> freeCabins = JsonConvert.DeserializeObject<List<Cabin>>(result);

            Console.WriteLine("Free Cabins In Facility :");
            DisplayCabin(freeCabins);
        }
    }
}
