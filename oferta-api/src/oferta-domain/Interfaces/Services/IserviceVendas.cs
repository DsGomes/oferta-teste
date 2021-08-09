using oferta_domain.Entities;

namespace oferta_domain.Interfaces.Services
{
    public interface IserviceVendas
    {
         void CadastrarVenda(int id_cliente, Endereco endereco, int[] produtos);
    }
}