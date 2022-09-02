using System.ComponentModel.DataAnnotations;

namespace TesteSinqia.Models
{
    public class PontoTuristicoModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(100, ErrorMessage = "Este campo deve conter no máximo 100 caracteres.")]
        [MinLength(1, ErrorMessage = "Este campo deve conter no mínimo 1 caractere.")]

        public string Descricao { get; set; }

        public string? Localizacao { get; set; }
    }
}
