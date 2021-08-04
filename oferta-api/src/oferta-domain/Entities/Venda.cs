namespace oferta_domain
{
    public partial class Venda
    {
        public long? Cliente { get; set; }
        public long? Produto { get; set; }

        public virtual Cliente Clientes { get; set; }
        public virtual Produto Produtos { get; set; }
    }
}
