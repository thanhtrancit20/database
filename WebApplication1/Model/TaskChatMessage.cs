using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class TaskChatMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChatMessageID { get; set; }

        public int TaskID_FK { get; set; }

        public int UserID_FK { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public string Message { get; set; }

        public bool IsEdited { get; set; } = false;

        public DateTime DateEdited { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
