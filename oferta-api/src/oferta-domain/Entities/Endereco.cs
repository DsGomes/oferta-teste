using System.ComponentModel.DataAnnotations;

namespace oferta_domain
{
    public class Endereco
    {
        [Key]
        public int cod_endereco { get; set; }
        public string rua { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public long cep { get; set; }
    }
}
