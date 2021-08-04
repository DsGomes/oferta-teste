using System.Collections.Generic;

namespace oferta_domain
{
    public partial class Endereco
    {
        public Endereco()
        {
            Clientes = new HashSet<Cliente>();
        }

        public long CodEndereco { get; set; }
        public string Rua { get; set; }
        public long Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public byte[] Cep { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
