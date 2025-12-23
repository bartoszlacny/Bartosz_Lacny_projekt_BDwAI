
using System.ComponentModel.DataAnnotations;

namespace Bartosz_Łacny_projekt_BDwAI.Models
{
    public class Cage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Numer boksu jest wymagany")]
        [Display(Name = "Oznaczenie boksu")]
        public string CageNumber { get; set; }

        [Display(Name = "Czy boks jest czysty?")]
        public bool IsClean { get; set; }

        public virtual ICollection<Animal>? Animals { get; set; }
    }
}