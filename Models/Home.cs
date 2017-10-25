using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace logReg.Models
{
    public class ViewUser
    {
        [Required]
        [MinLength(2)]
        [RegularExpression(@"\w")]
        public string firstName { get; set; }
        [Required]
        [MinLength(2)]
        [RegularExpression(@"\w")]
        public string lastName { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        [Compare("password")]
        public string confirmPassword { get; set; }
    }
    public class User
    {
        [Required]
        [MinLength(2)]
        [RegularExpression(@"\w")]
        public string firstName { get; set; }
        [Required]
        [MinLength(2)]
        [RegularExpression(@"\w")]
        public string lastName { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}