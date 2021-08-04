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
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodCliente);

                entity.ToTable("CLIENTES");

                entity.HasIndex(e => e.Cpf, "IX_CLIENTES_cpf")
                    .IsUnique();

                entity.Property(e => e.CodCliente).HasColumnName("cod_cliente");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnType("NUMERIC")
                    .HasColumnName("cpf");

                entity.Property(e => e.Credito).HasColumnName("credito");

                entity.Property(e => e.Endereco).HasColumnName("endereco");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnType("NUMERIC")
                    .HasColumnName("telefone");

                entity.HasOne(d => d.Enderecos)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Endereco);

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Status);
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.CodEndereco);

                entity.ToTable("ENDERECOS");

                entity.HasIndex(e => e.CodEndereco, "IX_ENDERECOS_cod_endereco")
                    .IsUnique();

                entity.Property(e => e.CodEndereco).HasColumnName("cod_endereco");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro");

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnType("NUMERIC")
                    .HasColumnName("cep");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade");

                entity.Property(e => e.Complemento).HasColumnName("complemento");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasColumnName("rua");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.CodProduto);

                entity.ToTable("PRODUTOS");

                entity.HasIndex(e => e.CodProduto, "IX_PRODUTOS_cod_produto")
                    .IsUnique();

                entity.Property(e => e.CodProduto)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_produto");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao");

                entity.Property(e => e.Preco).HasColumnName("preco");

                entity.Property(e => e.Tipo).HasColumnName("tipo");
            });

            modelBuilder.Entity<StatusCliente>(entity =>
            {
                entity.HasKey(e => e.CodStatus);

                entity.ToTable("STATUS_CLIENTE");

                entity.HasIndex(e => e.CodStatus, "IX_STATUS_CLIENTE_cod_status")
                    .IsUnique();

                entity.Property(e => e.CodStatus)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_status");

                entity.Property(e => e.ContabilizaVenda)
                    .IsRequired()
                    .HasColumnName("contabiliza_venda");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao");

                entity.Property(e => e.FinalizaCliente)
                    .IsRequired()
                    .HasColumnName("finaliza_cliente");
            });

            modelBuilder.Entity<TipoProduto>(entity =>
            {
                entity.HasKey(e => e.CodTipo);

                entity.ToTable("TIPO_PRODUTO");

                entity.HasIndex(e => e.CodTipo, "IX_TIPO_PRODUTO_cod_tipo")
                    .IsUnique();

                entity.Property(e => e.CodTipo).HasColumnName("cod_tipo");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo_produto");
            });

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VENDAS");

                entity.Property(e => e.Cliente).HasColumnName("cliente");

                entity.Property(e => e.Produto).HasColumnName("produto");

                entity.HasOne(d => d.Clientes)
                    .WithMany()
                    .HasForeignKey(d => d.Cliente);

                entity.HasOne(d => d.Produtos)
                    .WithMany()
                    .HasForeignKey(d => d.Produto);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
