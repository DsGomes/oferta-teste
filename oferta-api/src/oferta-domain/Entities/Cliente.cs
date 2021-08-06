using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oferta_domain
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int cod_cliente { get; set; }
        public long cpf { get; set; }
        public string nome { get; set; }
        public long telefone { get; set; }
        public double credito { get; set; }
        public int status { get; set; }

    }
}
