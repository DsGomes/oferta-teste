using System.ComponentModel.DataAnnotations;

namespace oferta_domain.Entities
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
