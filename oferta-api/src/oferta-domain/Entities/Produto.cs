using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oferta_domain
{
    public class Produto
    {
        [Key]
        public int cod_produto { get; set; }
        public string descricao { get; set; }
        public int tipo { get; set; }
        public double preco { get; set; }
    }
}
