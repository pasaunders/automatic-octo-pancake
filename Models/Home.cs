using System.ComponentModel.DataAnnotations;

namespace logReg.Models
{
    public class Index
    {
        public Login login {get;set;}
        public User user {get;set;}
    }
    public class User
    {
        [Required]
        [MinLength(2)]
        [RegularExpression(@"\w+")]
        public string firstName { get; set; }
        [Required]
        [MinLength(2)]
        [RegularExpression(@"\w+")]
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
    public class Login
    {
        [Required]
        public string firstName {get;set;}
        public string password {get;set;}
    }
}