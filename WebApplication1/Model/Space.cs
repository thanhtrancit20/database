using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class Space
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpaceID { get; set; }

        [MaxLength(200)]
        public string SpaceName { get; set; }

        public string SpaceDescription { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public int CreatedBy { get; set; }

        [MaxLength(30)]
        public string StripeRef { get; set; }

        public int Seats { get; set; }

        public bool IsActive { get; set; } = false;

        public bool IsDeleted { get; set; } = false;

        public DateTime DateToCancel { get; set; }
    }
}
