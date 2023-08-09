using System.ComponentModel.DataAnnotations;

namespace TicketManagementSystem.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
