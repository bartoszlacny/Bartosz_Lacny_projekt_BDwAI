using System.ComponentModel.DataAnnotations;
namespace Bartosz_Łacny_projekt_BDwAI.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa gatunku jest wymagana")]
        [StringLength(30, ErrorMessage = "Nazwa nie może być dłuższa niż 30 znaków")]
        [Display(Name = "Gatunek")]
        public string Name { get; set; }

        public virtual ICollection<Animal>? Animals { get; set; }
    }
}