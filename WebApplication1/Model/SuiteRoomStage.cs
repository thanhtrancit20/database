using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class SuiteRoomStage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StageID { get; set; }

        public int RoomID_FK { get; set; }

        [MaxLength(45)]
        public string StageName { get; set; }

        public byte StagePosition { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
