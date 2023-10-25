using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CursosOnline.Models
{
    public class Student
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [StringLength(80, ErrorMessage = "O campo nome pode conter no máximo 80 caracteres.")]
        [MinLength(5, ErrorMessage = "O campo nome deve conter no mínimo 5 caracteres.")]
        [DisplayName("Nome completo:")]
        [Required(ErrorMessage = "Informe o nome!")]
        public string Name { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [DisplayName("E-mail:")]
        [Required(ErrorMessage = "Informe o e-mail")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Celular:")]
        public string Cellphone { get; set; } = string.Empty;

        public List<Subscriber> Subscribers { get; set; } = new();

    }
}