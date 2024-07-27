using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class SuiteTaskUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskUserID { get; set; }

        public int TaskID_FK { get; set; }

        public int UserID_FK { get; set; }

        public byte UserRole { get; set; }

        public bool IsActive { get; set; } = false;

        public bool IsGuest { get; set; } = false;

        public bool IsDeleted { get; set; } = false;
    }
}
