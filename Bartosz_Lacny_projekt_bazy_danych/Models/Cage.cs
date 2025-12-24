
using System.ComponentModel.DataAnnotations;

namespace Bartosz_Lacny_projekt_bazy_danych.Models
{
    public class Cage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Numer boksu jest wymagany")]
        [Display(Name = "Oznaczenie klatki")]
        public string CageNumber { get; set; }

        [Display(Name = "Czy klatka jest czysta?")]
        public bool IsClean { get; set; }

        public virtual ICollection<Animal>? Animals { get; set; }
    }
}