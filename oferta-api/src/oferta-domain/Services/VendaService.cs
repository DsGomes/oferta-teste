using oferta_domain.Entities;
using oferta_domain.Interfaces;
using oferta_domain.Interfaces.Repositories;
using oferta_domain.Interfaces.Services;

namespace oferta_domain.Services
{
    public class VendaService : IserviceVendas
    {
        private readonly IRepositoryVendas _vendasRepository;
        private readonly IRepositoryEnderecos _enderecosRepository;

        public VendaService(IRepositoryVendas vendasRepository,
                                IRepositoryEnderecos enderecosRepository)
        {
            _vendasRepository = vendasRepository;
            _enderecosRepository = enderecosRepository;
        }

        public void CadastrarVenda(int id_cliente, Endereco endereco, int[] produtos)
        {
            if(endereco != null){
                _enderecosRepository.Add(endereco);
            }

            foreach(var produto in produtos){
                var venda = new Venda();
                venda.Cliente = id_cliente;
                venda.Produto = produto;

                _vendasRepository.Add(venda);
            }
        }
    }
}