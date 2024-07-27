using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class LibCountry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryID { get; set; }

        [MaxLength(255)]
        public string ISO { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string PrintableName { get; set; }

        [MaxLength(255)]
        public string ISO3 { get; set; }

        public int NumCode { get; set; }
    }
}
