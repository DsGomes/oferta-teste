using System.ComponentModel.DataAnnotations;

namespace oferta_domain.Entities
{
    public partial class TipoProduto
    {
        [Key]
        public long CodTipo { get; set; }
        public string Tipo { get; set; }
    }
}
