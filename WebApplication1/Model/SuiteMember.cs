using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class SuiteMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SuiteMemberID { get; set; }

        public int SuiteID_FK { get; set; }

        public int UserID_FK { get; set; }

        public byte UserRole { get; set; }

        public bool IsActive { get; set; } = false;

        public bool IsDeleted { get; set; } = false;

        public DateTime DateJoined { get; set; }

        public int InviteID_FK { get; set; }
    }
}
