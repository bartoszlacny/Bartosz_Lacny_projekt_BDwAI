
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bartosz_Lacny_projekt_bazy_danych.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Imię musi mieć od 2 do 50 znaków")]
        [Display(Name = "Imię zwierzaka")]
        public string Name { get; set; }

        [Range(0, 30, ErrorMessage = "Wiek musi być między 0 a 30 lat")]
        [Display(Name = "Wiek (lata)")]
        public int Age { get; set; }

        [Display(Name = "Opis")]
        public string? Description { get; set; }

        [Display(Name = "Gatunek")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        
        [Display(Name = "Klatka")]
        public int CageId { get; set; }
        [ForeignKey("CageId")]
        public virtual Cage? Cage { get; set; }

        public virtual ICollection<AdoptionApplication>? AdoptionApplications { get; set; }
    }
}