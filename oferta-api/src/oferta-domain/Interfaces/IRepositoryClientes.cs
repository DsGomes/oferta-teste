using System.Collections.Generic;

namespace oferta_domain.Interfaces
{
    public interface IRepositoryClientes : IRepositoryBase<Cliente>
    {
         IEnumerable<Cliente> getByName(string name);
         Cliente getByCPF(long cpf);
    }
}