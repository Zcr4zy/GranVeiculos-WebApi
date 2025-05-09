using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranVeiculos.Models
{
    public class Modelo
    {
        [Key]
        public int CodigoModelo { get; set; }

        [Required(ErrorMessage = "Insira o nome da marca")]
        [StringLength(30, ErrorMessage = "O nome do modelo deve possuir no máximo 30 caracteres")]
        public string Nome {get; set; }

        [Required]
        public int CodigoMarca { get; set; }

        [ForeignKey("CodigoMarca")] 
        public Marca Marca {get; set; }
    }
}