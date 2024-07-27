using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class SuiteTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskID { get; set; }

        public int RoomID_FK { get; set; }

        public int StageID_FK { get; set; }

        public short TaskSequence { get; set; }

        [MaxLength(200)]
        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        public int CreatedBy { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public bool HasTimeline { get; set; } = false;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public byte TaskStatus { get; set; }

        public byte TaskPriority { get; set; }

        public bool IsDeleted { get; set; } = false;

        public bool IsCompleted { get; set; } = false;

        public DateTime DateCompleted { get; set; }

        public bool IsArchived { get; set; } = false;
    }
}
