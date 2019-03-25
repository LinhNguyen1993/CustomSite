using System.ComponentModel.DataAnnotations;

namespace CustomSite.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}