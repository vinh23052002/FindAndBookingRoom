using System.ComponentModel.DataAnnotations;

namespace API.Dtos.User
{
    public class UserResponse
    {
        public string userID { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Password must be at least 8 characters, at least one uppercase letter, one lowercase letter and one number.")]
        public string password { get; set; }
        public string fullName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? email { get; set; }
        [RegularExpression(@"^\d{9,10}$", ErrorMessage = "Phone number must be 9 or 10 digits.")]
        public string phone { get; set; }
        public int roleID { get; set; }
        public int wardID { get; set; }
        public int districtID { get; set; }
        public int provinceID { get; set; }
        [DataType(DataType.Date)]
        public DateTime? deleteAt { get; set; }

    }

    public class TokenResponse
    {
        public string token { get; set; }
    }
}
