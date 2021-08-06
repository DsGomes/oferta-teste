namespace oferta_domain
{
    public partial class Cliente
    {
        public long CodCliente { get; set; }
        public byte[] Cpf { get; set; }
        public string Nome { get; set; }
        public byte[] Telefone { get; set; }
        public double Credito { get; set; }
        public long? Status { get; set; }
        public long? Endereco { get; set; }
    }
}
