using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Province
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int province_id { get; set; }
        public string province_name { get; set; }
        public string province_type { get; set; }

        public ICollection<District> Districts { get; set; }
    }
}
