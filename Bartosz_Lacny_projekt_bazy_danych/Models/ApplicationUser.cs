using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bartosz_Lacny_projekt_bazy_danych.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Imię")]
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        [MaxLength(100)]
        public string? LastName { get; set; }
    }
}