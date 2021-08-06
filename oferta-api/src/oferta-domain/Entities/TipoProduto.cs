using System.ComponentModel.DataAnnotations;

namespace oferta_domain
{
    public partial class TipoProduto
    {
        [Key]
        public long CodTipo { get; set; }
        public string Tipo { get; set; }
    }
}
