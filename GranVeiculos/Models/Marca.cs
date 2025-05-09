using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GranVeiculos.Models
{
    [Table("Marca")]
    public class Marca
    {
        [Key]
        public int CodigoMarca { get; set; }

        [Required(ErrorMessage = "Insira o nome da marca")]
        [StringLength(30, ErrorMessage = "O nome da marca deve possuir no máximo 30 caracteres")]
        public string Nome {get; set; }    
    }
}