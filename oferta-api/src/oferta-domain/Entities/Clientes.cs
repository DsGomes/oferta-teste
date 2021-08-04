namespace oferta_domain.Entities
{
    public class Clientes
    {
        public int cod_cliente { get; set; }
        public int cpf { get; set; }
        public string nome { get; set; }
        public int telefone { get; set; }
        public decimal credito { get; set; }
    }
}