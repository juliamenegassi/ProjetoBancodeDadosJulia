using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBanco.Models
{
    [Table("Hotel")]
    public class Hotel
    {
        [Column("HotelId")]
        [Display(Name = "Código do Hotel")]
        public int Id { get; set; }

        [Column("NomeHotel")]
        [Display(Name = "Nome do Hotel")]
        public string NomeHotel { get; set; } = string.Empty;

        [Column("EnderecoHotel")]
        [Display(Name = "Endereco do Hotel")]
        public string EnderecoHotel { get; set; } = string.Empty;
    }
}
