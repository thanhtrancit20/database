using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class UserLoginHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserLoginHistoryID { get; set; }

        [Required]
        public int UserID_FK { get; set; }

        [Required]
        public int UserLoginID_FK { get; set; }

        [Required]
        [MaxLength(100)]
        public string LoginName { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [MaxLength(45)]
        public string IpAddress { get; set; }

        [Required]
        public bool IsSuccess { get; set; }

        [MaxLength(500)]
        public string AccessToken { get; set; }

        [MaxLength(100)]
        public string Message { get; set; }
    }
}
