using AssetManagement.DTO;
using AssetManagementFrontend.Handlers;
using AssetManagementFrontend.TaskManagers;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace AssetManagementFrontend
{
    public class Program
    {

        static async Task Main(string[] args)
        {
            int option = 1;
            ReportManager reportManager = new ReportManager();
            EmployeeManager employeeManager = new EmployeeManager();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Seat Management Application");
                Console.WriteLine("1) Onboard Facility");
                Console.WriteLine("2) Onboard Seats");
                Console.WriteLine("3) Onboard MeetingRooms");
                Console.WriteLine("4) Onboard Cabins");
                Console.WriteLine("5) Add Aminities"); 
                Console.WriteLine("6) Upload Employees");
                Console.WriteLine("7) Allocate Employee to seat");
                Console.WriteLine("8) Report on free seats");
                Console.WriteLine("9) Report on Free Seats based on Facility");
                Console.WriteLine("10) Report of Free Cabins By Facility");
                Console.WriteLine("11) Search Employee");

                option = Convert.ToInt32(Console.ReadLine());
                
                switch (option)
                {
                    case 1:
                        FacilityManager facilityManager = new FacilityManager();
                        facilityManager.AddFacility();
                        break;
                    case 2:
                        SeatManager seatManager = new SeatManager();
                        seatManager.AddSeat();
                        break;
                    case 3:
                        MeetingRoomHandler meetingRoomHandler = new MeetingRoomHandler();
                        meetingRoomHandler.AddMeetingRoom();
                        break;
                    case 4:
                        CabinManager cabinManager = new CabinManager();
                        cabinManager.AddCabin();
                        break;
                    case 5:
                        AmenityManager amenityManager = new AmenityManager();
                        amenityManager.AddAminity();
                        break;
                    case 6:
                        
                        employeeManager.AddEmployee();
                        break;
                    case 7:
                        AllocationManager allocationManager = new AllocationManager();
                        allocationManager.AddAllocation();
                        break;
                    case 8:
                        
                        await reportManager.GetFreeSeats();
                        break;
                    case 9:
                        await reportManager.FreeSeatByFacility();
                        break;
                   
                    case 10:
                        await reportManager.FreeCabinByFacility();
                        break;

                    case 11:
                        Console.WriteLine("1) Search by name\n2) Search by Seat");
                        int searchCriteria = Convert.ToInt32(Console.ReadLine());
                        if (searchCriteria == 1)
                        {
                            employeeManager.SearchEmployeeByName();
                        }
                        else { 
                            employeeManager.SearchEmployeeBySeat();
                        }
                        break;


                    default: Console.WriteLine("wrong input");
                        break;

                    
                }

                Console.ReadLine();


            }
        }
    }
}