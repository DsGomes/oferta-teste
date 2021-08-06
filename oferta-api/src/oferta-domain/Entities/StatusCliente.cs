using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace oferta_domain
{
    public partial class StatusCliente
    {
        [Key]
        public int cod_status { get; set; }
        public string descricao { get; set; }
        public string finaliza_cliente { get; set; }
        public string contabiliza_venda { get; set; }
    }
}
