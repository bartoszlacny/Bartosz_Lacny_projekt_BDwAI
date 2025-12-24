
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bartosz_Lacny_projekt_bazy_danych.Models
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
        [Display(Name = "Data utworzenia wniosku")]
        public DateTime ApplicationDate { get; set; } = DateTime.Now;

        [Display(Name = "Imię zwierzaka")]
        public int AnimalId { get; set; }
        [ForeignKey("AnimalId")]
        public virtual Animal? Animal { get; set; }
    }
}
