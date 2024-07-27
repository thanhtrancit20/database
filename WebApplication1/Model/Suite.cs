using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class Suite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SuiteID { get; set; }

        public int SpaceID_FK { get; set; }

        public int CreatedBy { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [MaxLength(200)]
        public string SuiteName { get; set; }

        public string SuiteDescription { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
