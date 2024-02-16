using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBanco.Models
{
    [Table("Destino")]
    public class Destino
    {
        [Column("DestinoId")]
        [Display(Name = "Código do Destino")]
        public int Id { get; set; }

        [Column("NomeDestino")]
        [Display(Name = "Nome do Destino")]
        public string NomeDestino { get; set; } = string.Empty;
    }
}
