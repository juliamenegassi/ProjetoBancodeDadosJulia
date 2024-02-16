using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBanco.Models
{
    [Table("Transporte")]
    public class Transporte
    {
        [Column ("TransporteId")]
        [Display(Name = "Código do Transporte")]
        public int Id { get; set;}

        [Column("NomeTransporte")]
        [Display(Name = "Nome do Transporte")]
        public string NomeTransporte { get; set;} = string.Empty;
    }
}
