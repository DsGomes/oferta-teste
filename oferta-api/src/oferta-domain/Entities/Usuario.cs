using System.ComponentModel.DataAnnotations;

namespace oferta_domain.Entities
{
    public class Usuario
    {
        [Key]
        public int cod_usuario { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string role { get; set; }
    }
}