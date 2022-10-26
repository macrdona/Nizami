﻿using System.ComponentModel.DataAnnotations;

namespace Nizami.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";

    }
}