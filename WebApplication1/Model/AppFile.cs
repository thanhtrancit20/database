using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class AppFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileID { get; set; }

        public int UserID_FK { get; set; }

        public DateTime DateUploaded { get; set; } = DateTime.UtcNow;

        [MaxLength(200)]
        public string FileName_Actual { get; set; }

        [MaxLength(100)]
        public string FileName_Stored { get; set; }

        public int FileSize { get; set; }

        [MaxLength(5)]
        public string FileExtension { get; set; }

        public byte FileType { get; set; }

        public int FileTo { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
