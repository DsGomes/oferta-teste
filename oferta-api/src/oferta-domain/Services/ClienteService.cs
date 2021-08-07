using System.Linq;

namespace oferta_domain.Services
{
    public class ClienteService
    {
        public static bool ValidateCliente(Cliente cliente){
            if(string.IsNullOrEmpty(cliente.nome) ||
                    cliente.cpf.Equals(0) ||
                    cliente.telefone.Equals(0))
                return false;

            return true;
        }
    }
}