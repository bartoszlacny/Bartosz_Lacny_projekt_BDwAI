
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bartosz_Łacny_projekt_BDwAI.Models
{
    public class AdoptionApplication
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Musisz podać dane kontaktowe")]
        [EmailAddress(ErrorMessage = "Niepoprawny format email")]
        [Display(Name = "Email kontaktowy")]
        public string ContactEmail { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Wiadomość jest za długa")]
        [Display(Name = "Dlaczego chcesz adoptować?")]
        public string Message { get; set; }

        [DataType(DataType.Date)]
        public DateTime ApplicationDate { get; set; } = DateTime.Now;

        public int AnimalId { get; set; }
        [ForeignKey("AnimalId")]
        public virtual Animal? Animal { get; set; }
    }
}
