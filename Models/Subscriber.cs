using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CursosOnline.Models
{
    public class Subscriber
    {

        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o título.")]
        [StringLength(80, ErrorMessage = "O título pode conter no máximo 80 caracteres.")]
        [MinLength(5, ErrorMessage = "O título deve conter no mínimo 5 caracteres.")]
        [DisplayName("Título")]
        public string Title { get; set; } = string.Empty;
        
        [DataType(DataType.DateTime)]
        [DisplayName("Início:")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Data de expiração:")]
        public DateTime EndDate { get; set; }

        [DisplayName("ID do Aluno:")]
        [Required(ErrorMessage = "Aluno inválido.")]
        public string StudentId { get; set; } = string.Empty;

        [DisplayName("Aluno:")]
        public Student? Student { get; set; }

    }
}