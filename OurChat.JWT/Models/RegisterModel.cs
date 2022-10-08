using System.ComponentModel.DataAnnotations;

namespace OurChat.JWT.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "User Name is required")]
    public string? Username { get; set; }

    [Phone]
    [Required(ErrorMessage = "Phone Number is required")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}