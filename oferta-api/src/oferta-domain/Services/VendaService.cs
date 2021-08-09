using oferta_domain.Entities;
using oferta_domain.Interfaces;
using oferta_domain.Interfaces.Repositories;
using oferta_domain.Interfaces.Services;

namespace oferta_domain.Services
{
    public class VendaService : IserviceVendas
    {
        private readonly IRepositoryVendas _vendasRepository;

        public VendaService(IRepositoryVendas vendasRepository)
        {
            _vendasRepository = vendasRepository;
        }

        public void CadastrarVenda(int id_cliente, int[] produtos)
        {
            foreach(var produto in produtos){
                var venda = new Venda();
                venda.Cliente = id_cliente;
                venda.Produto = produto;

                _vendasRepository.Add(venda);
            }
        }
    }
}