using oferta_domain.Entities;

namespace oferta_api.Helpers
{
    public class Utils
    {
        public static bool ValidateCliente(Cliente cliente){
            if(string.IsNullOrEmpty(cliente.nome) ||
                    string.IsNullOrEmpty(cliente.cpf) ||
                    string.IsNullOrEmpty(cliente.telefone))
                return false;

            return true;
        }
    }
}