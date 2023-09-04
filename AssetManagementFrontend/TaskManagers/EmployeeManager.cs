using AssetManagement.DTO;
using AssetManagement.Model;
using AssetManagementFrontend.HttpHandler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementFrontend.Handlers
{
    public class EmployeeManager
    {
        HttpRequestHandler handler = new HttpRequestHandler();
        public async Task AddEmployee()
        {
            Console.Clear();
            Console.WriteLine("  Add Employee");
            Console.WriteLine("-------------------------------------------------------");


            Console.Write("\n Enter Employee Name : ");
            string employeeName = Console.ReadLine();
            Console.WriteLine("\nEnter Employee Department");
            int departmentId = Convert.ToInt32(Console.ReadLine());

            var employeeDto = new EmployeeDto
            {
                EmployeeName = employeeName,
                DepartmentId = departmentId,

            };

            List<EmployeeDto> empList = new List<EmployeeDto>();
            empList.Add(employeeDto);

            string employeeDtoJson = JsonConvert.SerializeObject(empList);
            handler.HttpPost("Employee/Add", employeeDtoJson);


        }
        public async Task SearchEmployeeByName() { 
            Console.Clear();
            Console.WriteLine("Enter Name :");
            string name = Console.ReadLine();

            var queryParameters = new Dictionary<string, string>
            {
                { "name", name }
            };
            string queryString = string.Join("&", queryParameters.Select(kv => $"{kv.Key}={kv.Value}"));
            string targetUrl = $"Employee/GetbyName/?{queryString}";

            var result = await handler.HttpGet(targetUrl);
            List<Employee> searchEmployeeResult = JsonConvert.DeserializeObject<List<Employee>>(result);

            Console.WriteLine("Employees with given Name :");
            foreach (Employee emp in searchEmployeeResult) {
                Console.WriteLine($"Emp Name : {emp.EmployeeName}, Emp Id: {emp.EmployeeId}, Emp Dept: {emp.Department}");
            }
        }

        public async Task SearchEmployeeBySeat() {
            Console.Clear();
            Console.WriteLine("Enter SeatId :");
            string AssetId = Console.ReadLine();

            var queryParameters = new Dictionary<string, string>
            {
                { "assetIdToFindSt", AssetId },
                { "assetTypeSt", "2"}
            };
            string queryString = string.Join("&", queryParameters.Select(kv => $"{kv.Key}={kv.Value}"));
            string targetUrl = $"Employee/GetbySeat/?{queryString}";

            var result = await handler.HttpGet(targetUrl);
            List<Employee> searchEmployeeResult = JsonConvert.DeserializeObject<List<Employee>>(result);

            Console.WriteLine("Employee with Given Seat :");
            foreach (Employee emp in searchEmployeeResult)
            {
                Console.WriteLine($"Emp Name : {emp.EmployeeName}, Emp Id: {emp.EmployeeId}, Emp Dept: {emp.Department}");
            }
        }
    }
}
