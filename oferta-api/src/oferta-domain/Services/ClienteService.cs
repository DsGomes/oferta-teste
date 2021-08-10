using System.Collections.Generic;
using System.Linq;
using oferta_domain.Entities;
using oferta_domain.Interfaces.Repositories;
using oferta_domain.Interfaces.Services;

namespace oferta_domain.Services
{
    public class ClienteService : IServiceClientes
    {
        private readonly IRepositoryClientes _clientesRepository;

        public ClienteService(IRepositoryClientes clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        public IEnumerable<Cliente> GetClienteByCPF(string cpf){
            var cliente = _clientesRepository.getByCPF(cpf).ToArray();
            if(cliente[0].status == 7 || cliente[0].status == 9 || cliente[0].status == 21)
                return null;

            return cliente;
        }

        public IEnumerable<Cliente> GetClienteByName(string name){
            var clientes = _clientesRepository.getByName(name);

            return clientes.Where(c=>c.status != 7 || c.status != 9 || c.status != 21);
        }
    }
}