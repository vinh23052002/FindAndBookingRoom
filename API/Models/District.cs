using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class District
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int district_id { get; set; }
        public string district_name { get; set; }
        public string district_type { get; set; }
        public string? lat { get; set; }
        public string? lng { get; set; }

        public int province_id { get; set; }

        [ForeignKey("province_id")]
        public Province Province { get; set; }

        public ICollection<Ward> Wards { get; set; }
    }
}
