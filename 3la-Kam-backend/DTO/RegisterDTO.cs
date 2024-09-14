using System.ComponentModel.DataAnnotations;

namespace _3la_Kam_backend.DTO
{
    public class RegisterDTO
    {
        public string userName { get; set; }
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
    }
}
