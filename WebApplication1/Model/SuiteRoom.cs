using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class SuiteRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomID { get; set; }

        public int SuiteID_FK { get; set; }

        [MaxLength(200)]
        public string RoomName { get; set; }

        public string RoomDescription { get; set; }

        public int RoomGroupID_FK { get; set; }

        public int CreatedBy { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public bool HasTimeline { get; set; } = false;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public byte RoomStatus { get; set; }

        public byte RoomPriority { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
