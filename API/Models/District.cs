using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class District
    {
        [Key]
        public int districtID { get; set; }
        public string districtName { get; set; }
        public string districtType { get; set; }
        public int provinceID { get; set; }

        [ForeignKey("provinceID")]
        public Province Province { get; set; }

        public ICollection<Ward> Wards { get; set; }
    }
}
