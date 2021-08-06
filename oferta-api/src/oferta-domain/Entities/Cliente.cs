using System.ComponentModel.DataAnnotations;

namespace oferta_domain
{
    public class Cliente
    {
        [Key]
        public int cod_cliente { get; set; }
        public long cpf { get; set; }
        public string nome { get; set; }
        public long telefone { get; set; }
        public double credito { get; set; }
        public int status { get; set; }
        public int endereco { get; set; }

    }
}
