using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;

namespace GranVeiculos.Models
{
    [Table("Veiculo")]
    public class Veiculo
    {
        [Key]
        public int CodigoVeiculo { get; set;}

        [Required(ErrorMessage = "Insira o ano de fabricação do veículo!")]
        public short AnoFabricacao { get; set;}
        
        [Required(ErrorMessage = "Insira o ano do modelo do veículo")]
        public short AnoModelo { get; set;}

        [Required(ErrorMessage = "Insira o valor do veículo")]
        [Column(TypeName = "numeric(10,2)")]
        public decimal Valor { get; set; }

        [StringLength(7, ErrorMessage = "O tamanho máximo para o campo placa é 7 caracteres")]
        public string Placa { get; set;} 


        [Required]
        public int CodigoModelo { get; set; }

        [ForeignKey("CodigoModelo")]
        public Modelo Modelo { get; set;}


        [Required]
        public int CodigoCor { get; set;}

        [ForeignKey("CodigoCor")]
        public Cor Cor {get; set;}
    }
}