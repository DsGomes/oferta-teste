using Microsoft.EntityFrameworkCore;
using oferta_domain;

namespace oferta_infra
{
    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<StatusCliente> StatusClientes { get; set; }
        public virtual DbSet<TipoProduto> TipoProdutos { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Filename=../../../data/oferta-database.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venda>().HasNoKey();
        }
    }
}
