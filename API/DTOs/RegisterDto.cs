using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto
{
    [Required]
    public string DisplayName { get; set; } = "";

   // [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    [MinLength(4, ErrorMessage = "Hemşehrim uygunsuz şifre girdin.")]
    public string Password { get; set; } = "";

}
