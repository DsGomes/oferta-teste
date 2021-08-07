using System.Collections.Generic;

namespace oferta_domain.Interfaces
{
    public interface IServiceClientes
    {
         Cliente GetClienteByCPF(long cpf);
         IEnumerable<Cliente> GetClienteByName(string name);
    }
}