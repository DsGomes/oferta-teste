using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oferta_domain.Entities
{
    public class Cliente
    {
        public Cliente(long cpf, string nome, long telefone, double credito)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.telefone = telefone;
            this.credito = credito;
            this.status = 1;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int cod_cliente { get; private set; }
        public long cpf { get; private set; }
        public string nome { get; private set; }
        public long telefone { get; private set; }
        public double credito { get; private set; }
        public int status { get; private set; }
    }
}
