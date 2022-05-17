using System.ComponentModel.DataAnnotations;

namespace AuctionDotNet.Data.Model.Auth
{
    public class ResetPasswordModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}
