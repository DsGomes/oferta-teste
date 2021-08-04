using System.Collections.Generic;

namespace oferta_domain
{
    public partial class StatusCliente
    {
        public StatusCliente()
        {
            Clientes = new HashSet<Cliente>();
        }

        public long CodStatus { get; set; }
        public string Descricao { get; set; }
        public string FinalizaCliente { get; set; }
        public string ContabilizaVenda { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
