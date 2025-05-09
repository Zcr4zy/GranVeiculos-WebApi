using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranVeiculos.Models
{
    [Table("Cor")]
    public class Cor
    {
        [Key]
        public int CodigoCor { get; set; }

        [Required(ErrorMessage = "Insira o nome da cor")]
        [StringLength(25, ErrorMessage = "O nome da cor deve possuir no máximo 25 caracteres")]
        public string Nome {get; set; }
    }
}