using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class UserLoginDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserLoginID { get; set; }

        [Required]
        public int UserID_FK { get; set; }

        [Required]
        [MaxLength(100)]
        public string LoginID { get; set; }

        [Required]
        [MaxLength(100)]
        public string LoginPassword { get; set; }

        [Required]
        public bool IsFirstTimeLogin { get; set; }

        [Required]
        public int FailAttempts { get; set; }

        [Required]
        public bool IsLocked { get; set; }
    }
}
