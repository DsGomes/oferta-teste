using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oferta_domain.Entities
{
    [Table("STATUS_CLIENTE")]
    public partial class StatusCliente
    {
        [Key]
        public int cod_status { get; set; }
        public string descricao { get; set; }
        public string finaliza_cliente { get; set; }
        public string contabiliza_venda { get; set; }
    }
}
