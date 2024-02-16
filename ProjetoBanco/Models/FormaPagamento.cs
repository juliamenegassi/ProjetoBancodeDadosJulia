using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBanco.Models
{
    [Table("FormaPagamento")]
    public class FormaPagamento
    {
        [Column("FormaPagamentoId")]
        [Display(Name = "Código da Forma de Pagamento")]
        public int Id { get; set; }

        [Column("NomeFormaPagamento")]
        [Display(Name = "Nome da Forma de Pagamento")]
        public string NomeFormaPagamento { get; set; } = string.Empty;
    }
}
