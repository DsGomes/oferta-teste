using System.Collections.Generic;
using System.Linq;
using oferta_domain.Interfaces;

namespace oferta_domain.Services
{
    public class ClienteService
    {
        private readonly IRepositoryClientes _clientesRepository;

        public ClienteService(IRepositoryClientes clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        public Cliente GetClienteByCPF(long cpf){
            var cliente = _clientesRepository.getByCPF(cpf);
            if(cliente.status == 7 || cliente.status == 9 || cliente.status == 21)
                return null;

            return cliente;
        }

        public IEnumerable<Cliente> GetClienteByName(string name){
            var clientes = _clientesRepository.getByName(name);

            return clientes.Where(c=>c.status != 7 || c.status != 9 || c.status != 21);
        }
    }
}