using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class LoginTwoFactorModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string TwoFactorCode { get; set; }
        public bool RememberMe { get; set; }
    }
}
