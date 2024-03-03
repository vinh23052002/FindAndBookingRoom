using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Province
    {
        [Key]
        public int provinceID { get; set; }
        public string provinceName { get; set; }
        public string provienceType { get; set; }

        public ICollection<District> Districts { get; set; }
    }
}
