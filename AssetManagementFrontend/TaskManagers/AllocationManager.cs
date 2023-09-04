using AssetManagement.DTO;
using AssetManagementFrontend.HttpHandler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementFrontend.TaskManagers
{
    public class AllocationManager
    {
        HttpRequestHandler handler = new HttpRequestHandler();
        public async Task AddAllocation()
        {
            AllocationDto allocationDto = new AllocationDto();

            Console.WriteLine("---------------Add Allocation--------------");

            Console.WriteLine("Employee Id :");
            allocationDto.EmployeeId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Asset : \n 1) Cabin\n 2) Seat");
            allocationDto.AssetLookupId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Asset Id : ");
            allocationDto.AssetId = Convert.ToInt32(Console.ReadLine());

            string allocationDtoJson = JsonConvert.SerializeObject(allocationDto);
            handler.HttpPost("Allocation/Add", allocationDtoJson);
        }
    }
}
