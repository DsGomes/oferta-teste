using System.Collections.Generic;
using oferta_domain.Entities;

namespace oferta_domain.Interfaces.Repositories
{
    public interface IRepositoryClientes : IRepositoryBase<Cliente>
    {
         IEnumerable<Cliente> getByName(string name);
         IEnumerable<Cliente> getByCPF(string cpf);
    }
}