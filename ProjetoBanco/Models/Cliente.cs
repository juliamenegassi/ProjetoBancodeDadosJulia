using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBanco.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Column("ClienteId")]
        [Display(Name = "Código do Cliente")]
        public int Id { get; set; }

        [Column("NomeCliente")]
        [Display(Name = "Nome do Cliente")]
        public string NomeCliente { get; set; } = string.Empty;

        [Column("CpfCliente")]
        [Display(Name = "Cpf do Cliente")]
        public string ClienteCpf { get; set; } = string.Empty;

        [Column("TelefoneCliente")]
        [Display(Name = "Telefone do Cliente")]
        public string TelefoneCliente { get; set; } = string.Empty;

        [Column("EmailCliente")]
        [Display(Name = "Email do Cliente")]
        public string EmailCliente { get; set; } = string.Empty;
    }
}
