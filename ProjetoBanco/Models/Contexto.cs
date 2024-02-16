using Microsoft.EntityFrameworkCore;

namespace ProjetoBanco.Models
{
    public class Contexto : DbContext
    {
         public Contexto(DbContextOptions<Contexto>options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set;}

        public DbSet<Destino> Destino { get; set; }

        public DbSet<FormaPagamento> FormaPagamento { get; set; }

        public DbSet<Hospedagem> Hospedagem { get; set; }

        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<Transporte> Transporte { get; set; }

        public DbSet<Viagem> Viagem{ get; set; }
    }
}
