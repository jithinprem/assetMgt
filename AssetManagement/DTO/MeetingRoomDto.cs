using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.DTO
{
    public class MeetingRoomDto
    {
        public int Chairs { get; set; }
        public int FacilityId { get; set; }

    }
}
