using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBanco.Models
{
    [Table("Viagem")]
    public class Viagem
    {
        [Column("ViagemId")]
        [Display(Name = "Código da Viagem")]
        public int Id { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [ForeignKey("HospedagemId")]
        public int HospedagemId { get; set; }
        public Hospedagem? Hospedagem { get; set; }

        [ForeignKey("TransporteId")]
        public int TransporteId { get; set; }
        public Transporte? Transporte { get; set; }

        [Column("PrecoViagem")]
        [Display(Name = "Preço da Viagem")]
        public string PrecoViagem { get; set; } = string.Empty;

        [Column("FormaPagamento")]

        public int FormaPagamentoId { get; set; }

        [Display(Name = "Forma de Pagamento")]
        public FormaPagamento? FormaPagamento { get; set; }
    }
}
