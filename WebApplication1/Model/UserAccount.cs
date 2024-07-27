using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication1.Model
{
    public class UserAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime DateDeleted { get; set; }

        [MaxLength(200)]
        public string AvatarPath { get; set; }

        [MaxLength(100)]
        public string EmailAddress { get; set; }

        [MaxLength(50)]
        public string ContactNumber { get; set; }

        [MaxLength(50)]
        public string MobileNumber { get; set; }

        [MaxLength(30)]
        public string StripeRef { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsActive { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [Required]
        [DefaultValue((byte)3)]
        public byte AccountType { get; set; }

        public short AccountTimeZone { get; set; }

        [Required]
        public bool IsVerified { get; set; }
    }
}
